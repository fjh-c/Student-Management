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
        private readonly Lazy<IRepository<StudentInfo>> repStudentInfo;

        public IUnitOfWork UnitOfWork { get; }
        public IRepository<StudentInfo> RepositoryStudentInfo { get { return repStudentInfo.Value; } }

        public StudentInfoService(IUnitOfWork unitOfWork, Lazy<IRepository<StudentInfo>> repStudentInfo)
        {
            this.UnitOfWork = unitOfWork;
            this.repStudentInfo = repStudentInfo;
        }

        public IList<StudentInfo> QueryList()
        {
            return RepositoryStudentInfo.TableNoTracking.ToList();
        }
    }
}
