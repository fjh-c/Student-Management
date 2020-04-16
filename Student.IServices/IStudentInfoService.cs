using System;
using System.Collections.Generic;
using System.Text;
using yrjw.ORM.Chimp;
using Student.Model;
using System.Threading.Tasks;
using Student.DTO;

namespace Student.IServices
{
    public interface IStudentInfoService
    {
        IUnitOfWork UnitOfWork { get; }

        IList<StudentInfoDTO> QueryList();
    }
}
