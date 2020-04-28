using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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
    public class StudentInfoService: IStudentInfoService, IDependency
    {
        private readonly Lazy<IMapper> _mapper;
        private readonly Lazy<IRepository<StudentInfo>> repStudentInfo;
        private readonly Lazy<IRepository<Depart>> repDepart;

        public IUnitOfWork UnitOfWork { get; }

        public StudentInfoService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, 
            Lazy<IRepository<StudentInfo>> repStudentInfo, 
            Lazy<IRepository<Depart>> repDepart)
        {
            this._mapper = mapper;
            this.UnitOfWork = unitOfWork;
            this.repStudentInfo = repStudentInfo;
            this.repDepart = repDepart;
        }

        public async Task<IResultModel> Query(long id)
        {
            var info = await repStudentInfo.Value.TableNoTracking.ProjectTo<StudentInfoDTO>(_mapper.Value.ConfigurationProvider).FirstAsync(p => p.Id == id);
            return ResultModel.Success(info);
        }

        public async Task<IResultModel> QueryList()
        {
            var list = await repStudentInfo.Value.TableNoTracking.ProjectTo<StudentInfoDTO>(_mapper.Value.ConfigurationProvider).ToListAsync();
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> Insert(StudentInfoDTO model)
        {
            var entity = _mapper.Value.Map<StudentInfo>(model);
            //外键判断
            var dept = repDepart.Value.GetById(entity.DepartId);
            if (dept == null || dept.DeptType != Model.Enums.EnumDeptType.classes)
            {
                return ResultModel.Failed("error：Departid does not exist or the EnumDeptType is not classes");
            }
            await repStudentInfo.Value.InsertAsync(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(entity);
            }
            return ResultModel.Failed("error：Insert Save failed");
        }

        public async Task<IResultModel> Update(StudentInfoDTO model)
        {
            //主键判断
            var entity = await repStudentInfo.Value.GetByIdAsync(model.Id);
            if(entity == null)
            {
                return ResultModel.Failed("error：entity Id does not exist");
            }
            //外键判断
            var dept = repDepart.Value.GetById(model.DepartId);
            if (dept == null || dept.DeptType != Model.Enums.EnumDeptType.classes)
            {
                return ResultModel.Failed("error：Departid does not exist or the EnumDeptType is not classes");
            }
            _mapper.Value.Map(model, entity);
            repStudentInfo.Value.Update(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(entity);
            }
            return ResultModel.Failed("error：Insert Save failed");
        }

        public async Task<IResultModel> Delete(long id)
        {
            //主键判断
            var entity = await repStudentInfo.Value.GetByIdAsync(id);
            if (entity == null)
            {
                return ResultModel.Failed("error：entity Id does not exist");
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
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success("Delete succeeded");
            }
            return ResultModel.Failed("error：Delete failed");
        }
    }
}
