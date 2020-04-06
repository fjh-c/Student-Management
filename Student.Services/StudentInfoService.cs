using Student.IServices;
using Student.Model;
using System;
using yrjw.ORM.Chimp;

namespace Student.Services
{
    public class StudentInfoService: IStudentInfoService, IDependency
    {
        private readonly Lazy<IRepository<StudentInfo>> repStudentInfo;

        public IUnitOfWork UnitOfWork { get; }
        public IRepository<StudentInfo> RepositoryStudentInfo { get { return repStudentInfo.Value; } }

        public StudentInfoService(IUnitOfWork unitOfWork, Lazy<IRepository<StudentInfo>> repStudentInfo)
        {
            this.UnitOfWork = unitOfWork;
            this.repStudentInfo = repStudentInfo;
        }
    }
}
