using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
