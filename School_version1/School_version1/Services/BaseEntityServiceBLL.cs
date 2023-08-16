using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using School_version1.Context;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public abstract class BaseEntityService<T, TDto, TAddOrUpdateDto> where T : class where TDto : class where TAddOrUpdateDto : class
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

        public virtual async Task<TDto> Get(Guid id)
        {
            var entity = await _db.Set<T>().FindAsync(id);

            return _mapper.Map<T, TDto>(entity);
        }

        public virtual async Task<List<TDto>> GetAll(int Page)
        {
            // skip 10
            int PagesSkip = Page * 10;
            var entity = await _db.Set<T>().Skip(PagesSkip).Take(10).ToListAsync(); 
            return _mapper.Map<List<TDto>>(entity).ToList();
        }
        public virtual async Task<int> GetAllCount()
        {
            var entity = await _db.Set<T>().CountAsync();
            return entity;
        }

        public virtual async Task<bool> Post(TAddOrUpdateDto dto)
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

        public virtual async Task<bool> Put(Guid id, TDto addOrUpdateDto)
        {
            var dataEntity = await _db.Set<T>().FindAsync(id);

            if (dataEntity == null)
            {
                return false;
            }
            _db.Entry(dataEntity).State = EntityState.Modified;
            _mapper.Map<TDto, T>(addOrUpdateDto, dataEntity);
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }

}
