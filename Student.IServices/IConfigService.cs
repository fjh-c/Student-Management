using yrjw.ORM.Chimp;
using System.Threading.Tasks;
using yrjw.ORM.Chimp.Result;
using Student.DTO;
using Student.Model;

namespace Student.IServices
{
    public interface IConfigService : IBaseService<Config, ConfigDTO, int>
    {
        /// <summary>
        /// 获取配置脚本
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<IResultModel> GetValue(string code);
    }
}
