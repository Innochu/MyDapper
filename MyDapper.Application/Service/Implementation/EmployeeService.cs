﻿using MyDapper.Application.Service.Interface;
using MyDapper.Persistence.Repository.Interface;

namespace MyDapper.Application.Service.Implementation
{
   
        internal sealed class EmployeeService : IEmployeeService
        {
            private readonly IRepositoryManager _repository;
           // private readonly ILoggerManager _logger;

            public EmployeeService(IRepositoryManager repository  /* ILoggerManager logger*/)
            {
                _repository = repository;
              //  _logger = logger;
            }
        }
    
}