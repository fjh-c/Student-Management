using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using yrjw.ORM.Chimp;
using yrjw.ORM.Chimp.Result;

namespace Student.IServices
{
    public interface IBaseService<TEntityDTO,TKey> where TEntityDTO : class
    {
        IUnitOfWork UnitOfWork { get; }
        Task<IResultModel> Query(TKey id);
    }
}
