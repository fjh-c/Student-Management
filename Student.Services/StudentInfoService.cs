using AutoMapper;
using AutoMapper.QueryableExtensions;
using Student.DTO;
using Student.IServices;
using Student.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yrjw.ORM.Chimp;

namespace Student.Services
{
    public class StudentInfoService: IStudentInfoService, IDependency
    {
        private readonly IMapper _mapper;
        private readonly Lazy<IRepository<StudentInfo>> repStudentInfo;

        public IUnitOfWork UnitOfWork { get; }

        public StudentInfoService(IMapper mapper, IUnitOfWork unitOfWork, Lazy<IRepository<StudentInfo>> repStudentInfo)
        {
            this._mapper = mapper;
            this.UnitOfWork = unitOfWork;
            this.repStudentInfo = repStudentInfo;
        }

        public IList<StudentInfoDTO> QueryList()
        {
            return repStudentInfo.Value.TableNoTracking.ProjectTo<StudentInfoDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
