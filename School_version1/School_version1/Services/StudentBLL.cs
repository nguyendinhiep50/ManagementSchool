using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;

namespace School_version1.Services
{
    public class StudentBLL:IStudent
    {
        private readonly DbContextSchool _Db;
        public StudentBLL(DbContextSchool db)
        {
            _Db = db;
        }

        public async Task<bool> DeleteStudent(Guid id)
        {
            try
            {
                var student = await _Db.Students.FindAsync(id);
                _Db.Students.Remove(student);
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

        public async Task<List<Student>> GetAllStudent()
        {
            return await _Db.Students.ToListAsync();
        }

        public async Task<Student> GetStudent(Guid id)
        {
            return await _Db.Students.FindAsync(id);
        }

        public async Task<Boolean> PostStudent(Student student)
        {
            try
            {
                _Db.Students.Add(student);
                await _Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<Student> PutStudent(Guid id, Student student)
        {
            _Db.Entry(student).State = EntityState.Modified;
            try
            {
                await _Db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return student;
        }
    }
}
