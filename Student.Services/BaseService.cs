using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Student.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yrjw.ORM.Chimp;
using yrjw.ORM.Chimp.Result;

namespace Student.Services
{
    public class BaseService<TEntity, TEntityDTO, TKey> : IBaseService<TEntity, TEntityDTO, TKey> where TEntityDTO : class where TEntity : Model.EntityBase<TKey>, new() where TKey: struct
    {
        protected readonly ILogger<BaseService<TEntity, TEntityDTO, TKey>> _logger;
        protected readonly Lazy<IMapper> _mapper;
        /// <summary>
        /// TEntity仓储
        /// </summary>
        protected readonly Lazy<IRepository<TEntity>> _repository;
        /// <summary>
        /// 工作单元
        /// </summary>
        public IUnitOfWork UnitOfWork { get; }

        public BaseService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<BaseService<TEntity, TEntityDTO, TKey>> logger,
            Lazy<IRepository<TEntity>> repository)
        {
            _logger = logger;
            _mapper = mapper;
            UnitOfWork = unitOfWork;
            this._repository = repository;
        }

        public virtual async Task<IResultModel> Query(TKey id)
        {
            var info = await _repository.Value.GetByIdAsync(id);
            return ResultModel.Success(_mapper.Value.Map<TEntityDTO>(info));
        }

        public virtual async Task<IResultModel> QueryList()
        {
            var list = await _repository.Value.TableNoTracking.OrderByDescending(k => k.Id).ProjectTo<TEntityDTO>(_mapper.Value.ConfigurationProvider).ToListAsync();
            return ResultModel.Success(list);
        }

        public virtual async Task<IResultModel> Insert(TEntityDTO model)
        {
            var entity = _mapper.Value.Map<TEntity>(model);
            await _repository.Value.InsertAsync(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(_mapper.Value.Map<TEntityDTO>(entity));
            }
            _logger.LogError($"error：Insert Save failed");
            return ResultModel.Failed("error：Insert Save failed");
        }

        public virtual async Task<IResultModel> Update(TEntityDTO model)
        {
            //主键判断
            var entity = await _repository.Value.GetByIdAsync(((dynamic)model).Id);
            if (entity == null)
            {
                _logger.LogError($"error：entity Id {((dynamic)model).Id} does not exist");
                return ResultModel.NotExists;
            }
            _mapper.Value.Map(model, entity);
            _repository.Value.Update(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(entity);
            }
            _logger.LogError($"error：Update Save failed");
            return ResultModel.Failed("error：Update Save failed");
        }

        public virtual async Task<IResultModel> Update(IEnumerable<TEntityDTO> models)
        {
            var entitys = new List<TEntity>();
            foreach (var model in models)
            {
                //主键判断
                var entity = await _repository.Value.GetByIdAsync(((dynamic)model).Id);
                if (entity == null)
                {
                    _logger.LogError($"error：entity Id {((dynamic)model).Id} does not exist");
                    return ResultModel.NotExists;
                }
                entitys.Add(entity);
            }
            _repository.Value.Update(entitys);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.LogError($"error：Updates Save failed");
            return ResultModel.Failed("error：Updates Save failed");
        }

        public virtual async Task<IResultModel> Delete(TKey id)
        {
            //主键判断
            var entity = await _repository.Value.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogError($"error：entity Id：{id} does not exist");
                return ResultModel.NotExists;
            }
            //软删除
            if (entity.Deleted == 0)
            {
                entity.Deleted = 1;
                _repository.Value.Update(entity);
            }
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.LogError($"error：Delete failed");
            return ResultModel.Failed("error：Delete failed");
        }

        public virtual async Task<IResultModel> Delete(IList<TKey> ids)
        {
            foreach (var id in ids)
            {
                //主键判断
                var entity = await _repository.Value.GetByIdAsync(id);
                if (entity == null)
                {
                    _logger.LogError($"error：entity Id：{id} does not exist");
                    return ResultModel.NotExists;
                }
                //软删除
                if (entity.Deleted == 0)
                {
                    entity.Deleted = 1;
                    _repository.Value.Update(entity);
                } 
            }
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.LogError($"error：Delete failed");
            return ResultModel.Failed("error：Delete failed");
        }

        public virtual async Task<IResultModel> Remove(TKey id)
        {
            //主键判断
            var entity = await _repository.Value.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogError($"error：entity Id：{id} does not exist");
                return ResultModel.NotExists;
            }
            _repository.Value.Delete(entity);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.LogError($"error：Remove failed");
            return ResultModel.Failed("error：Remove failed");
        }

        public virtual async Task<IResultModel> Remove(IList<TKey> ids)
        {
            foreach (var id in ids)
            {
                //主键判断
                var entity = await _repository.Value.GetByIdAsync(id);
                if (entity == null)
                {
                    _logger.LogError($"error：entity Id：{id} does not exist");
                    return ResultModel.NotExists;
                }
                _repository.Value.Delete(entity);
            }
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.LogError($"error：Remove failed");
            return ResultModel.Failed("error：Remove failed");
        }
    }
}
