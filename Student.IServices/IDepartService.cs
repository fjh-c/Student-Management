using yrjw.ORM.Chimp;
using System.Threading.Tasks;
using yrjw.ORM.Chimp.Result;
using Student.DTO;

namespace Student.IServices
{
    public interface IDepartService
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IResultModel> Query(int id);
        Task<IResultModel> QueryList();
        Task<IResultModel> QueryPagedList(int pageIndex, int pageSize, string search);
        Task<IResultModel> Insert(DepartDTO model);
        Task<IResultModel> Update(DepartDTO model);
        Task<IResultModel> Delete(int id, bool isSave = true);
    }
}
