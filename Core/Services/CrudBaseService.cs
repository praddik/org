using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public abstract class CrudBaseService<T, TId> : ICrudBaseService<T, TId> where T : class, IEntity
    {
        private readonly IBaseRepository<T, TId> _repository;

        protected CrudBaseService(IBaseRepository<T, TId> baseRepository)
        {
            _repository = baseRepository;
        }

        public virtual async Task<T> Create(T newEntity)
            => await _repository.Create(newEntity);


        public virtual async Task Delete(T entity)
            => await _repository.Delete(entity);

        public virtual async Task<IEnumerable<T>> GetAll()
            => await _repository.GetAll();


        public virtual async Task<T> Update(T entity)
            => await _repository.Update(entity);


        public virtual async Task<T> GetById(TId id)
            => await _repository.GetById(id);
    }
}
