using MyDapper.Application.Service.Interface;
using MyDapper.Persistence.Repository.Interface;

namespace MyDapper.Application.Service.Implementation
{
   
        internal sealed class CompanyService : ICompanyService
        {
            private readonly IRepositoryManager _repository;
           // private readonly ILoggerManager _logger;
            public CompanyService(IRepositoryManager repository /*ILoggerManager logger*/)
            {
                _repository = repository;
               // _logger = logger;
            }
        }
    
}
