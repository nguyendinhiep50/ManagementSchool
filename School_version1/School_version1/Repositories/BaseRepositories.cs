using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Repositories
{
    public class BaseRepositories<T, TDto, TAddOrUpdateDto> : IBaseRepositories<T, TDto, TAddOrUpdateDto> where T : class where TDto : class where TAddOrUpdateDto : class
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

        public virtual async Task<TDto> Get(Guid id)
        {
            var Result = await _db.Set<T>().FindAsync(id).AsTask();
            return _mapper.Map<TDto>(Result);
        }

        public virtual async Task<List<TDto>> GetAll()
        {
            var Result = await _db.Set<T>().ToListAsync();
            return _mapper.Map<List<TDto>>(Result);
        }

        public virtual async Task<TAddOrUpdateDto> Post(TAddOrUpdateDto dto)
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

        public virtual async Task<Boolean> Put(Guid id, TDto entity)
        {
            var dataEntity = await _db.Set<T>().FindAsync(id);

            if (dataEntity == null)
            {
                return false;
            }

            _mapper.Map(entity, dataEntity); // Cập nhật thuộc tính của đối tượng đã tải

            _db.Entry(dataEntity).State = EntityState.Modified; // Đánh dấu đối tượng đã thay đổi

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

        public virtual async Task<TDto> LoginToken(LoginAddDto dto)
        {
            try
            {
                var Login = await _db.Managements.Where(x => x.ManagementEmail == dto.LoginEmail && x.ManagementPassword == dto.PassWorld).FirstOrDefaultAsync();
                return _mapper.Map<TDto>(Login);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return null;
        }
    }
}
