using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;

namespace School_version1.Services
{
    public class TeacherBLL : ITeacher
    {
        private readonly DbContextSchool _Db;
        public TeacherBLL(DbContextSchool db)
        {
            _Db = db;
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

        public async Task<bool> PostTeacher(Teacher teacher)
        {
            try
            {
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
