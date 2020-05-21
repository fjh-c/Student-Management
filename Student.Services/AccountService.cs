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
    public class AccountService : IAccountService, IDependency
    {
        private readonly ILogger<AccountService> _logger;
        private readonly Lazy<IMapper> _mapper;
        private readonly Lazy<IRepository<Account>> repAccount;

        public IUnitOfWork UnitOfWork { get; }

        public AccountService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<AccountService> logger,
            Lazy<IRepository<Account>> repAccount)
        {
            _logger = logger;
            _mapper = mapper;
            UnitOfWork = unitOfWork;
            this.repAccount = repAccount;
        }

        public async Task<IResultModel> Query(Guid id)
        {
            var info = await repAccount.Value.GetByIdAsync(id);
            return ResultModel.Success(_mapper.Value.Map<AccountDTO>(info));
        }

        public async Task<IResultModel> QueryList()
        {
            var list = await repAccount.Value.TableNoTracking.ProjectTo<AccountDTO>(_mapper.Value.ConfigurationProvider).ToListAsync();
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> Insert(AccountDTO model)
        {
            var entity = _mapper.Value.Map<Account>(model);

            //检查用户名是否唯一
            if (model.UserName.NotNull())
            {
                var isusername = await repAccount.Value.TableNoTracking.AnyAsync(p => p.UserName == model.UserName.Trim());
                if (isusername)
                {
                    _logger.LogError($"ErrorCode：{EnumErrorCode.UserName.ToInt()}，UserName：{model.UserName}，{EnumErrorCode.UserName.ToDescription()}");
                    return ResultModel.Failed(EnumErrorCode.UserName.ToDescription(), EnumErrorCode.UserName.ToInt());
                }
            }

            await repAccount.Value.InsertAsync(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(entity);
            }
            _logger.LogError($"error：Insert Save failed");
            return ResultModel.Failed("添加失败");
        }

        public Task<IResultModel> Update(AccountDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<IResultModel> Delete(Guid id, bool isSave = true)
        {
            throw new NotImplementedException();
        }
    }
}
