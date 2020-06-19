using Auth.Jwt;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Student.DTO;
using Student.IServices;
using Student.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yrjw.ORM.Chimp;
using yrjw.ORM.Chimp.Result;

namespace Student.Services
{
    public class DepartService : BaseService<Depart, DepartDTO, int>, IDepartService, IDependency
    {
        public DepartService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<DepartService> logger, Lazy<ILoginInfo> loginInfo,
            Lazy<IRepository<Depart>> _repository) : base(mapper, unitOfWork, logger, loginInfo, _repository)
        { }

        public async Task<IResultModel> GetPagedListAsync(int pageIndex, int pageSize, string search)
        {
            var data = _repository.Value.TableNoTracking;
            if (!search.IsNull())
            {
                data = data.Where(p => p.DepartName.Contains(search));
            }
            var list = await data.ProjectTo<DepartDTO>(_mapper.Value.ConfigurationProvider).ToPagedListAsync(pageIndex, pageSize);
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> GetClassesListAsync()
        {
            var data = _repository.Value.TableNoTracking.Where(p => p.DeptType == Model.Enums.EnumDeptType.classes);
            var list = await data.ProjectTo<DepartDTO>(_mapper.Value.ConfigurationProvider).ToListAsync();
            return ResultModel.Success(list);
        }

        public override async Task<IResultModel> InsertAsync(DepartDTO model)
        {
            //外键判断
            if (model.GradeId.HasValue)
            {
                var dept = _repository.Value.GetById(model.GradeId);
                if (dept == null || dept.DeptType != Model.Enums.EnumDeptType.grade)
                {
                    _logger.LogError($"error：GradeId {model.GradeId} does not exist or the EnumDeptType is not grade");
                    return ResultModel.Failed("外键不存在，或上级部门必须指定年组", "GradeId");
                }
            }
            //调用父类方法
            return await base.InsertAsync(model);
        }

        public override async Task<IResultModel> UpdateAsync(DepartDTO model)
        {
            //外键判断
            if (model.GradeId.HasValue)
            {
                var dept = _repository.Value.GetById(model.GradeId);
                if (dept == null || dept.DeptType != Model.Enums.EnumDeptType.grade)
                {
                    _logger.LogError($"error：GradeId {model.GradeId} does not exist or the EnumDeptType is not grade");
                    return ResultModel.Failed("外键不存在，或上级部门必须指定年组", "GradeId");
                }
            }
            //调用父类方法
            return await base.UpdateAsync(model);
        }
    }
}
