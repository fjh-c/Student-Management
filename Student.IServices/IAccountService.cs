using yrjw.ORM.Chimp;
using System.Threading.Tasks;
using yrjw.ORM.Chimp.Result;
using Student.DTO;
using System;

namespace Student.IServices
{
    public interface IAccountService
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IResultModel> Query(Guid id);
        Task<IResultModel> QueryList();
        Task<IResultModel> Insert(AccountDTO model);
        Task<IResultModel> Update(AccountDTO model);
        Task<IResultModel> Delete(Guid id, bool isSave = true);
    }
}
