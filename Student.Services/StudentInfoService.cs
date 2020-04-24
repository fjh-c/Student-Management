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

        public IUnitOfWork UnitOfWork { get; }

        public StudentInfoService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, Lazy<IRepository<StudentInfo>> repStudentInfo)
        {
            this._mapper = mapper;
            this.UnitOfWork = unitOfWork;
            this.repStudentInfo = repStudentInfo;
        }

        public async Task<IResultModel> Query(long id)
        {
            var info = await repStudentInfo.Value.GetByIdAsync(id);
            return ResultModel.Success(_mapper.Value.Map<StudentInfoQuery>(info));
        }

        public async Task<IResultModel> QueryList()
        {
            var list = await repStudentInfo.Value.TableNoTracking.ProjectTo<StudentInfoQuery>(_mapper.Value.ConfigurationProvider).ToListAsync();
            return ResultModel.Success(list);
        }
    }
}
