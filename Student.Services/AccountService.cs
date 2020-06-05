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
            //默认密码
            if (model.PassWord.IsNull())
            {
                model.PassWord = "123456";
            }
            var entity = _mapper.Value.Map<Account>(model);

            //检查用户名是否唯一
            if (model.UserName.NotNull())
            {
                var isusername = await repAccount.Value.TableNoTracking.AnyAsync(p => p.UserName == model.UserName.Trim());
                if (isusername)
                {
                    _logger.LogError($"error：UserName {model.UserName} already exists");
                    return ResultModel.Failed("用户名已存在", "UserName");
                }
            }

            await repAccount.Value.InsertAsync(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(entity);
            }
            _logger.LogError($"error：Insert Save failed");
            return ResultModel.Failed("error：Insert Save failed");
        }

        public async Task<IResultModel> Update(AccountDTO model)
        {
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
                var isusername = await repAccount.Value.TableNoTracking.AnyAsync(p => p.UserName == model.UserName.Trim() && p.Id != model.Id);
                if (isusername)
                {
                    _logger.LogError($"error：UserName {model.UserName} already exists");
                    return ResultModel.Failed("用户名已存在", "UserName");
                }
            }
            string _pwd = entity.PassWord;
            _mapper.Value.Map(model, entity);
            //密码空则保留原密码
            if (model.PassWord.IsNull())
            {
                entity.PassWord = _pwd;
            }
            repAccount.Value.Update(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(entity);
            }
            _logger.LogError($"error：Update Save failed");
            return ResultModel.Failed("error：Update Save failed");
        }

        public async Task<IResultModel> Delete(Guid id)
        {
            //初始化操作员禁止删除
            if (id == Guid.Parse("39F08CFD-8E0D-771B-A2F3-2639A62CA2FA"))
            {
                return ResultModel.Failed("初始化数据不能删除");
            }
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
            return ResultModel.Failed("error：Delete failed");
        }

        public async Task<IResultModel> UpdatePassword(UpdatePasswordDTO model)
        {
            //主键判断
            var entity = await repAccount.Value.GetByIdAsync(model.AccountId);
            if (entity == null)
            {
                _logger.LogError($"error：entity AccountId {model.AccountId} does not exist");
                return ResultModel.NotExists;
            }
            //原密码验证
            if (!entity.PassWord.Equals($"{entity.UserName}_{model.OldPassword}".ToMd5Hash()))
            {
                return ResultModel.Failed("原密码错误", "OldPassword");
            }
            entity.PassWord = $"{entity.UserName}_{model.NewPassword}".ToMd5Hash();
            repAccount.Value.Update(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.LogError($"error：UpdatePassword failed");
            return ResultModel.Failed("error：UpdatePassword failed");
        }
    }
}
