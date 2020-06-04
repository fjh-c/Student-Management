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
    public class DepartService : IDepartService, IDependency
    {
        private readonly ILogger<DepartService> _logger;
        private readonly Lazy<IMapper> _mapper;
        private readonly Lazy<IRepository<Depart>> repDepart;

        public IUnitOfWork UnitOfWork { get; }

        public DepartService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<DepartService> logger,
            Lazy<IRepository<Depart>> repDepart)
        {
            _logger = logger;
            _mapper = mapper;
            UnitOfWork = unitOfWork;
            this.repDepart = repDepart;
        }

        public async Task<IResultModel> Query(int id)
        {
            var info = await repDepart.Value.GetByIdAsync(id);
            return ResultModel.Success(_mapper.Value.Map<DepartDTO>(info));
        }

        public async Task<IResultModel> QueryList()
        {
            var list = await repDepart.Value.TableNoTracking.ProjectTo<DepartDTO>(_mapper.Value.ConfigurationProvider).ToListAsync();
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> QueryPagedList(int pageIndex, int pageSize, string search)
        {
            var data = repDepart.Value.TableNoTracking;
            if (!search.IsNull())
            {
                data = data.Where(p => p.DepartName.Contains(search));
            }
            var list = await data.ProjectTo<DepartDTO>(_mapper.Value.ConfigurationProvider).ToPagedListAsync(pageIndex, pageSize);
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> Insert(DepartDTO model)
        {
            var entity = _mapper.Value.Map<Depart>(model);
            //外键判断
            if (entity.GradeId.HasValue)
            {
                var dept = repDepart.Value.GetById(entity.GradeId);
                if (dept == null || dept.DeptType != Model.Enums.EnumDeptType.grade)
                {
                    _logger.LogError($"error：Departid {entity.GradeId} does not exist or the EnumDeptType is not grade");
                    return ResultModel.Failed("error：Departid does not exist or the EnumDeptType is not grade");
                }
            }
            await repDepart.Value.InsertAsync(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(entity);
            }
            _logger.LogError($"error：Insert Save failed");
            return ResultModel.Failed("error：Insert Save failed");
        }

        public async Task<IResultModel> Update(DepartDTO model)
        {
            //主键判断
            var entity = await repDepart.Value.GetByIdAsync(model.Id);
            if(entity == null)
            {
                _logger.LogError($"error：entity Id {model.Id} does not exist");
                return ResultModel.NotExists;
            }
            //外键判断
            if (entity.GradeId.HasValue)
            {
                var dept = repDepart.Value.GetById(entity.GradeId);
                if (dept == null || dept.DeptType != Model.Enums.EnumDeptType.grade)
                {
                    _logger.LogError($"ErrorCode：{EnumErrorCode.GradeId.ToInt()}，GradeId：{model.GradeId}，{EnumErrorCode.GradeId.ToDescription()}");
                    return ResultModel.Failed(EnumErrorCode.GradeId.ToDescription(), EnumErrorCode.GradeId.ToInt());
                }
            }
            _mapper.Value.Map(model, entity);
            repDepart.Value.Update(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(entity);
            }
            _logger.LogError($"error：Update Save failed");
            return ResultModel.Failed("error：Update Save failed");
        }

        public async Task<IResultModel> Delete(int id, bool isSave = true)
        {
            //主键判断
            var entity = await repDepart.Value.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogError($"error：entity Id {id} does not exist");
                return ResultModel.NotExists;
            }
            //数据库中删除
            repDepart.Value.Delete(entity);
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
