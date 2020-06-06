using yrjw.ORM.Chimp;
using System.Threading.Tasks;
using yrjw.ORM.Chimp.Result;
using Student.DTO;
using Student.Model;

namespace Student.IServices
{
    public interface IStudentInfoService: IBaseService<StudentInfo, StudentInfoDTO, long>
    {
        Task<IResultModel> QueryPagedList(int pageIndex, int pageSize, string search);
    }
}
