using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository<T, TId> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(TId id);

        Task<T> Create(T newEntity);

        Task<T> Update(T entity);

        Task Delete(T entity);
    }
}
