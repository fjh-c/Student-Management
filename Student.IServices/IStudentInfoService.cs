using yrjw.ORM.Chimp;
using System.Threading.Tasks;
using yrjw.ORM.Chimp.Result;
using Student.DTO;

namespace Student.IServices
{
    public interface IStudentInfoService
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IResultModel> Query(long id);
        Task<IResultModel> QueryList();
        Task<IResultModel> Insert(StudentInfoDTO model);
        Task<IResultModel> Update(StudentInfoDTO model);
        Task<IResultModel> Delete(long id);
    }
}
