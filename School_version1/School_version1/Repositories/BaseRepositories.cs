using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Repositories
{
    public class BaseRepositories<T, TDto> : IBaseRepositories<T, TDto> where T : class where TDto : class
    {
        protected DbContextSchool _db { get; private set; }  // can use when inherit
        protected IMapper _mapper;

        public BaseRepositories(DbContextSchool db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public virtual async Task<Guid> Delete(Guid id)
        {
            try
            {
                var entity = await _db.Set<T>().FindAsync(id);
                if (entity == null)
                    return id;

                _db.Set<T>().Remove(entity);
                await _db.SaveChangesAsync();
                return id;
            }
            catch
            {
                return Guid.Empty;
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

        public virtual async Task<TDto> Post(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                _db.Set<T>().Add(entity);
                await _db.SaveChangesAsync();
                return dto;
            }
            catch
            {
                return dto;
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
