using Auth.Jwt;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Student.DTO;
using Student.IServices;
using Student.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yrjw.ORM.Chimp;
using yrjw.ORM.Chimp.Result;

namespace Student.Services
{
    public class ConfigService : BaseService<Config, ConfigDTO, int>, IConfigService, IDependency
    {
        public ConfigService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<ConfigService> logger, Lazy<ILoginInfo> loginInfo,
            Lazy<IRepository<Config>> _repository) : base(mapper, unitOfWork, logger, loginInfo, _repository)
        {
        }

        public async Task<IResultModel> GetValue(string code)
        {
            var entity = await _repository.Value.TableNoTracking.FirstOrDefaultAsync(p => p.Code == code);
            if (entity == null)
            {
                _logger.LogError($"error：entity Code {code} does not exist");
                return ResultModel.NotExists;
            }
            return ResultModel.Success(_mapper.Value.Map<ConfigDTO>(entity));
        }
    }
}
