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
            //按类型展示可见账户列表，不返回密码
            var list = await repAccount.Value.TableNoTracking.ProjectTo<AccountDTO>(_mapper.Value.ConfigurationProvider).ToListAsync();
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> Insert(AccountDTO model)
        {
            //仅系统操作员拥有权限
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

        public async Task<IResultModel> Update(AccountDTO model)
        {
            //除系统操作员，只能修改自己信息
            //主键判断
            var entity = await repAccount.Value.GetByIdAsync(model.Id);
            if (entity == null)
            {
                _logger.LogError($"error：entity Id {model.Id} does not exist");
                return ResultModel.NotExists;
            }
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
            _mapper.Value.Map(model, entity);
            repAccount.Value.Update(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(entity);
            }
            _logger.LogError($"error：Update Save failed");
            return ResultModel.Failed("修改失败");
        }

        public async Task<IResultModel> Delete(Guid id)
        {
            //仅系统操作员拥有权限
            //自己不能删除自己

            //主键判断
            var entity = await repAccount.Value.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogError($"error：entity Id：{id} does not exist");
                return ResultModel.NotExists;
            }
            
            repAccount.Value.Delete(entity);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.LogError($"error：Delete failed");
            return ResultModel.Failed("删除失败");
        }
    }
}
