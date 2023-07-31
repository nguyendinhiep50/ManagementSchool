using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;

namespace School_version1.Services
{
    public abstract class BaseEntityService<T, TDto> where T : class where TDto : class
    {
        protected DbContextSchool _db { get; private set; }  // can use when inherit
        protected IMapper _mapper;

        public BaseEntityService(DbContextSchool db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            try
            {
                var entity = await _db.Set<T>().FindAsync(id);
                if (entity == null)
                    return false;

                _db.Set<T>().Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual Task<T> Get(Guid id)
        {
            return _db.Set<T>().FindAsync(id).AsTask();
        }

        public virtual Task<List<T>> GetAll()
        {
            return _db.Set<T>().ToListAsync();
        }

        public virtual async Task<bool> Post(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                _db.Set<T>().Add(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<T> Put(Guid id, T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }
    }

}
