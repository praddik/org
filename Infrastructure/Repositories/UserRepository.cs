using Core.Entities;
using Core.Interfaces.Repositories;
namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
