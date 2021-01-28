using AutoMapper;
using Beautymakeup.Common.Snowflake;
using Beautymakeup.Core.UnitOfWork;
using Beautymakeup.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Model.Services
{
    public interface IBaseService
    {
    }
    public class BaseService : IBaseService
    {
        public readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        public readonly IMapper _mapper;
        public readonly IdWorker _idWorker;

        public BaseService(IUnitOfWork<ApplicationDbContext> unitOfWork, IMapper mapper, IdWorker idWorker)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _idWorker = idWorker;
        }
    }
}
