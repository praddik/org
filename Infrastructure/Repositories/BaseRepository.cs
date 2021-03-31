using Core.Interfaces;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T, TId> : IBaseRepository<T, TId> where T : class, IEntity
    {
        private readonly ApplicationContext _context;
        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T newEntity)
        {
            newEntity.CreatedAt = SystemClock.Instance.GetCurrentInstant();
            newEntity.UpdatedAt = SystemClock.Instance.GetCurrentInstant();
            await _context.Set<T>().AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return newEntity;
        }


        public virtual async Task Delete(T entity)
        {
            _context.Set<T>()
                         .Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
            => await _context.Set<T>().ToListAsync();


        public virtual async Task<T> GetById(TId id)
            => await _context.Set<T>().FindAsync(id);



        public virtual async Task<T> Update(T entity)
        {
            entity.UpdatedAt = SystemClock.Instance.GetCurrentInstant();
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
