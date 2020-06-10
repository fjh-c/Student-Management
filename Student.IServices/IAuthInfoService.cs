using yrjw.ORM.Chimp;
using System.Threading.Tasks;
using yrjw.ORM.Chimp.Result;
using Student.DTO;
using Student.Model;

namespace Student.IServices
{
    public interface IAuthInfoService : IBaseService<AuthInfo, AuthInfoDTO, int>
    {
    }
}
