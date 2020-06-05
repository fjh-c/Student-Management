using AutoMapper;
using Microsoft.Extensions.Logging;
using Student.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using yrjw.ORM.Chimp;
using yrjw.ORM.Chimp.Result;

namespace Student.Services
{
    public class BaseService<TEntity, TEntityDTO, TKey> : IBaseService<TEntityDTO, TKey> where TEntityDTO : class where TEntity : class
    {
        protected readonly ILogger<BaseService<TEntity, TEntityDTO, TKey>> _logger;
        protected readonly Lazy<IMapper> _mapper;
        protected readonly Lazy<IRepository<TEntity>> _repository;

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
    }
}
