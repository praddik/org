using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class CrudCompanyService : CrudBaseService<Company, int>, ICrudCompanyService
    {
        private readonly ICompanyRepository _repository;

        public CrudCompanyService(ICompanyRepository baseRepository) : base(baseRepository)
        {
        }
    }
}
