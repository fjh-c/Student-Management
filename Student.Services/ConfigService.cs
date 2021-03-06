﻿using Auth.Jwt;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cache.MemoryCache;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Student.DTO;
using Student.DTO.Cache;
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
        public ConfigService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<ConfigService> logger, Lazy<ILoginInfo> loginInfo, Lazy<ICacheHandler> cacheHandler,
            Lazy<IRepository<Config>> _repository) : base(mapper, unitOfWork, logger, loginInfo, cacheHandler, _repository)
        {
        }

        public async Task<IResultModel> GetValue(string code)
        {
            var _cachekey = $"{CacheKeys.CONFIG_CODE}:{code.ToUpper()}";
            if (!_cacheHandler.Value.TryGetValue(_cachekey, out ConfigDTO configDTO))
            {
                var entity = await _repository.Value.TableNoTracking.FirstOrDefaultAsync(p => p.Code.ToUpper() == code.ToUpper());
                if (entity == null)
                {
                    _logger.LogError($"error：entity Code {code} does not exist");
                    return ResultModel.NotExists;
                }
                configDTO = _mapper.Value.Map<ConfigDTO>(entity);
                //加入缓存
                await _cacheHandler.Value.SetAsync(_cachekey, configDTO);
            }
            return ResultModel.Success(configDTO);
        }

        public async Task<IResultModel> SetValue(ConfigDTO model)
        {
            var entity = _repository.Value.TableNoTracking.FirstOrDefault(p => p.Code.ToUpper() == model.Code.ToUpper());
            if (entity == null)
            {
                return ResultModel.NotExists;
            }
            var configDTO = _mapper.Value.Map<ConfigDTO>(entity);

            #region 校验json格式
            try
            {
                switch (model.Code.ToUpper())
                {
                    case "AUTH":
                        model.Value.ToJson<AuthConfigData>();
                        break;
                }
            }
            catch (Exception)
            {
                return ResultModel.Failed("error ToJson DeserializeObject");
            }
            #endregion

            //删除配置信息缓存
            await _cacheHandler.Value.RemoveAsync($"{CacheKeys.CONFIG_CODE}:{model.Code.ToUpper()}");

            configDTO.Value = model.Value;
            return await base.UpdateAsync(configDTO);
        }
    }
}
