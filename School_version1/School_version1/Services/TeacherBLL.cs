using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Interface;
using School_version1.Models.DTOs;
using School_version1.Models.ObjectData;

namespace School_version1.Services
{

    public class TeacherBLL : ITeacher
    {
        private readonly DbContextSchool _Db;
        private readonly IMapper _mapper;
        public TeacherBLL(DbContextSchool db, IMapper mapper)
        {
            _Db = db;
            _mapper = mapper;
        }
        public async Task<bool> DeleteTeacher(Guid id)
        {
            try
            {
                var teacher = await _Db.Teachers.FindAsync(id);
                _Db.Teachers.Remove(teacher);
                await _Db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }

        public async Task<List<Teacher>> GetAllTeacher()
        {
            return await _Db.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacher(Guid id)
        {
            return await _Db.Teachers.FindAsync(id);
        }

        public async Task<bool> PostTeacher(TeacherDto TeacherDto)
        {
            try
            {
                var teacher = _mapper.Map<Teacher>(TeacherDto);
                _Db.Teachers.Add(teacher);
                await _Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<Teacher> PutTeacher(Guid id, Teacher teacher)
        {
            _Db.Entry(teacher).State = EntityState.Modified;
            try
            {
                await _Db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return teacher;
        }
    }
}
