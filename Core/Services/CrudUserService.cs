using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class CrudUserService : CrudBaseService<User, int>, ICrudUserService
    {
        private readonly IUserRepository _repository;

        public CrudUserService(IUserRepository baseRepository) : base(baseRepository)
        {
        }
    }
}
