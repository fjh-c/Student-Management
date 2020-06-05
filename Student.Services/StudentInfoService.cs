using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Student.DTO;
using Student.IServices;
using Student.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using yrjw.ORM.Chimp;
using yrjw.ORM.Chimp.Result;

namespace Student.Services
{
    public class StudentInfoService: IStudentInfoService, IDependency
    {
        private readonly ILogger<StudentInfoService> _logger;
        private readonly Lazy<IMapper> _mapper;
        private readonly Lazy<IRepository<StudentInfo>> repStudentInfo;
        private readonly Lazy<IRepository<Depart>> repDepart;

        public IUnitOfWork UnitOfWork { get; }

        public StudentInfoService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<StudentInfoService> logger,
            Lazy<IRepository<StudentInfo>> repStudentInfo, 
            Lazy<IRepository<Depart>> repDepart)
        {
            _logger = logger;
            _mapper = mapper;
            UnitOfWork = unitOfWork;
            this.repStudentInfo = repStudentInfo;
            this.repDepart = repDepart;
        }

        public async Task<IResultModel> Query(long id)
        {
            var info = await repStudentInfo.Value.GetByIdAsync(id);
            return ResultModel.Success(_mapper.Value.Map<StudentInfoDTO>(info));
        }

        public async Task<IResultModel> QueryList()
        {
            var list = await repStudentInfo.Value.TableNoTracking.Where(p => p.Deleted == 0).OrderByDescending(k => k.Id).ProjectTo<StudentInfoDTO>(_mapper.Value.ConfigurationProvider).ToListAsync();
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> QueryPagedList(int pageIndex, int pageSize, string search)
        {
            var data = repStudentInfo.Value.TableNoTracking.Where(p => p.Deleted == 0);
            if (!search.IsNull())
            {
                if (search.IsMobileNumber())
                {
                    data = data.Where(p => p.Phone == search);
                }
                else if (search.IsIdentityCard())
                {
                    data = data.Where(p => p.IdentityCard == search);
                }
                else if (search.IsEmail())
                {
                    data = data.Where(p => p.Email == search);
                }
                else if (search.IsNumeric())
                {
                    data = data.Where(p => p.Id == search.ToLong());
                }
                else
                {
                    data = data.Where(p => p.Name.Contains(search));
                }
            }
            var list = await data.OrderByDescending(k => k.Id).ProjectTo<StudentInfoDTO>(_mapper.Value.ConfigurationProvider).ToPagedListAsync(pageIndex, pageSize);
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> Insert(StudentInfoDTO model)
        {
            var entity = _mapper.Value.Map<StudentInfo>(model);
            //外键判断
            var dept = repDepart.Value.GetById(model.DepartId);
            if (dept == null || dept.DeptType != Model.Enums.EnumDeptType.classes)
            {
                _logger.LogError($"error：DepartId {entity.DepartId} does not exist or the EnumDeptType is not classes");
                return ResultModel.Failed("外键不存在，或部门必须指定班级", "DepartId");
            }
            //检查手机号是否唯一
            if (model.Phone.NotNull())
            {
                var isphone = await repStudentInfo.Value.TableNoTracking.AnyAsync(p => p.Phone == model.Phone);
                if (isphone)
                {

                    _logger.LogError($"error：Phone {model.Phone} It's not the only one");
                    return ResultModel.Failed("该手机号已被其他账号绑定使用", "Phone");
                }
            }
            //检查身份证号是否唯一
            if (model.IdentityCard.NotNull())
            {
                var isIdentityCard = await repStudentInfo.Value.TableNoTracking.AnyAsync(p => p.IdentityCard == model.IdentityCard);
                if (isIdentityCard)
                {
                    _logger.LogError($"error：IdentityCard {model.IdentityCard} It's not the only one");
                    return ResultModel.Failed("该身份证号已被其他账号绑定使用", "IdentityCard");
                }
            }

            await repStudentInfo.Value.InsertAsync(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(_mapper.Value.Map<StudentInfoDTO>(entity)); //返回模型一定要DTO一下，否则导航属性数据拿不到
            }
            _logger.LogError($"error：Insert Save failed");
            return ResultModel.Failed("error：Insert Save failed");
        }

        public async Task<IResultModel> Update(StudentInfoDTO model)
        {
            //主键判断
            var entity = await repStudentInfo.Value.GetByIdAsync(model.Id);
            if(entity == null)
            {
                _logger.LogError($"error：entity Id {model.Id} does not exist");
                return ResultModel.NotExists;
            }
            //外键判断
            var dept = repDepart.Value.GetById(model.DepartId);
            if (dept == null || dept.DeptType != Model.Enums.EnumDeptType.classes)
            {
                _logger.LogError($"error：DepartId {model.DepartId} does not exist or the EnumDeptType is not classes");
                return ResultModel.Failed("外键不存在，或部门必须指定班级", "DepartId");
            }
            _mapper.Value.Map(model, entity);
            repStudentInfo.Value.Update(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(entity);
            }
            _logger.LogError($"error：Update Save failed");
            return ResultModel.Failed("error：Update Save failed");
        }

        public async Task<IResultModel> Delete(long id, bool isSave = true)
        {
            //主键判断
            var entity = await repStudentInfo.Value.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogError($"error：entity Id：{id} does not exist");
                return ResultModel.NotExists;
            }
            //软删除
            if(entity.Deleted == 0)
            {
                entity.Deleted = 1;
                repStudentInfo.Value.Update(entity);
            }
            else
            {
                //数据库中删除
                repStudentInfo.Value.Delete(entity);
            }
            if (!isSave)
            {
                return ResultModel.Success();
            }
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.LogError($"error：Delete failed");
            return ResultModel.Failed("error：Delete failed");
        }
    }
}
