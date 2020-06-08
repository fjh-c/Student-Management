using yrjw.ORM.Chimp;
using System.Threading.Tasks;
using yrjw.ORM.Chimp.Result;
using Student.DTO;
using Student.Model;

namespace Student.IServices
{
    public interface IDepartService : IBaseService<Depart, DepartDTO, int>
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<IResultModel> GetPagedListAsync(int pageIndex, int pageSize, string search);

        /// <summary>
        /// 获取所有班级列表
        /// </summary>
        /// <returns></returns>
        Task<IResultModel> GetClassesListAsync();
    }
}
