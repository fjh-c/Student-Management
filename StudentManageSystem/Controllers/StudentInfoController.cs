using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Student.DTO;
using StudentManageSystem.HttpApis;
using StudentManageSystem.ViewModels;
using WebApiClient.Parameterables;
using yrjw.ORM.Chimp.Result;

namespace StudentManageSystem.Controllers
{
    public class StudentInfoController : Controller
    {
        private readonly ILogger<StudentInfoController> _logger;
        public readonly IStudentInfoApi _studentInfoApi;
        public readonly IDepartApi _separtApi;

        public StudentInfoController(ILogger<StudentInfoController> logger, IStudentInfoApi studentInfoApi, IDepartApi departApi)
        {
            _logger = logger;
            _studentInfoApi = studentInfoApi;
            _separtApi = departApi;
        }

        //学生信息列表展示页面
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //添加页面
        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            await GetDepartList();
            return View();
        }

        //修改页面
        [HttpGet]
        public async Task<IActionResult> EditAsync(long? id)
        {
            var result = await _studentInfoApi.GetStudentInfoAsync(id.Value);
            if (result.Success == false)
            {
                return View();  //建议跳转到指定错误页面
            }
            await GetDepartList();
            return View(result.Data);
        }

        //获取部门下拉选择列表数据
        private async Task GetDepartList()
        {
            var result = await _separtApi.GetDepartClassesListAsync();
            var list = result.Data.Select(p => new SelectListItem(p.DepartName, p.Id.ToString(), false, p.GradeId == null));
            ViewBag.DepartClassesList = list;
        }

        //表单提交，保存学生信息，id=0 添加，id>0 修改
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAsync(StudentInfoDTO model)
        {
            if (ModelState.IsValid)
            {
                IResultModel result;
                MulitpartFile file = null;
                if (model.PhotosFile != null && model.PhotosFile.Length > 0)
                {
                    file = new MulitpartFile(model.PhotosFile.OpenReadStream(), model.PhotosFile.FileName);
                }
                if (model.Id == 0)
                {
                    //result = await _studentInfoApi.PostStudentInfoInsertAsync(model, file);

                    //通过json提交模型，上传图片必须转Base64传输
                    if (model.PhotosFile != null && model.PhotosFile.Length > 0)
                    {
                        byte[] bytes = new byte[model.PhotosFile.OpenReadStream().Length];
                        model.PhotosFile.OpenReadStream().Read(bytes, 0, bytes.Length);
                        model.Photos = Convert.ToBase64String(bytes);
                        model.PhotosFile = null; //这里清空数据，否则传输序列化时出错
                    } 
                    result = await _studentInfoApi.PostStudentInfoInsertAsync(model);
                }
                else
                {
                    result = await _studentInfoApi.PutStudentInfoUpdateAsync(model, file);
                }
                if (result.Success)
                {
                    var _msg = model.Id == 0 ? "添加成功！" : "修改成功！";
                    return RedirectToAction("ShowMsg", "Home", new { msg = _msg });
                }
                else
                {
                    if (result.FailedId.NotNull())
                    {
                        ModelState.AddModelError(result.FailedId, result.Msg);
                    }
                    else
                    {
                        ModelState.AddModelError("error", result.Msg);
                    }
                }
            }
            await GetDepartList();
            if (model.Id == 0)
            {
                return View("Create", model);
            }
            return View("Edit", model);
        }

        //删除操作 ajax请求返回json
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _studentInfoApi.DeleteStudentInfoAsync(id);
            return Json(new Result() { success = result.Success, msg = result.Msg });
        }

        //批量删除操作 ajax请求返回json
        public async Task<IActionResult> DeleteAllAsync(long[] arr)
        {
            var result = await _studentInfoApi.DeleteAllStudentInfoAsync(arr);
            return Json(new Result() { success = result.Success, msg = result.Msg });
        }

        //详情页面查看
        public async Task<IActionResult> DetailsAsync(long? id)
        {
            var result = await _studentInfoApi.GetStudentInfoAsync(id.Value);
            if (result.Data.Photos.IsNull())
            {
                result.Data.Photos = "/images/upload-img.jpg";
            }
            else
            {
                result.Data.Photos = Code.ViewsHelper.GetStudentPhotosPath(result.Data.Photos);
            }
            
            if (result.Success == false)
            {
                return View();  //建议跳转到指定错误页面
            }
            return View(result.Data);
        }

        //Layui数据表格异步获取展示列表数据
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public async Task<IActionResult> GetQueryPagedListAsync(int page, int limit, string search)
        {
            var result = await _studentInfoApi.GetStudentInfoPagedListAsync(page, limit, search);
            foreach (var item in result.Data.Item)
            {
                if (item.Photos.IsNull())
                {
                    item.Photos = "/images/upload-img.jpg";
                    continue;
                }
                item.Photos = Code.ViewsHelper.GetStudentPhotosPath(item.Photos);
            }
            if (result.Success)
            {
                return Json(new Table() { data = result.Data.Item, count = result.Data.Total });
            }
            return Json(new Table() { data = null, count = 0 });
        }
    }
}
