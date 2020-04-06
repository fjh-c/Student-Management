using System;
using System.Collections.Generic;
using System.Text;
using yrjw.ORM.Chimp;
using Student.Model;

namespace Student.IServices
{
    public interface IStudentInfoService
    {
        IUnitOfWork UnitOfWork { get; }
        IRepository<StudentInfo> RepositoryStudentInfo { get; }
    }
}
