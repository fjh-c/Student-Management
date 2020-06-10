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
    public class AuthInfoService : BaseService<AuthInfo, AuthInfoDTO, int>, IAuthInfoService, IDependency
    {
        public AuthInfoService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<AuthInfoService> logger,
            Lazy<IRepository<AuthInfo>> _repository) : base(mapper, unitOfWork, logger, _repository)
        {}

    }
}
