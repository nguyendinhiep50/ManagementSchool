using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;

using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class StudentServices : BaseEntityService<Student, StudentDto, StudentAddDto>, IStudent
    {
        public StudentServices(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<List<StudentDto>> GetAllStudentFaculty(int page,int size)
        {
            int PagesSkip = (page -1)  * size;
            var entity = await _db.Set<Student>().Include(x=>x.Faculty).Skip(PagesSkip).Take(size).ToListAsync();
            return _mapper.Map<List<StudentDto>>(entity).ToList();
        }

        public async Task<List<StudentDto>> GetAllStudentsInFaculty(Guid id)
        {
            var students = await _db.Students.Where(x => x.FacultyId == id).ToListAsync();
            foreach (var st in students)
                st.Faculty = _db.Faculty.Find(id);
            return _mapper.Map<List<StudentDto>>(students).ToList();
        }

        //public async Task<StudentDto> PostLoginToken(LoginAddDto loginAccount)
        //{
        //    try
        //    {
        //        var student = await _db.Students.Where(x => x.StudentPassword == loginAccount.PassWorld && x.StudentEmail == loginAccount.LoginEmail).FirstOrDefaultAsync();
        //        return _mapper.Map<StudentDto>(student);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //        throw;
        //    }
        //    return null;
        //}

        public async Task<StudentDto> GetStudentFaculty(Guid id)
        {
            var student = await _db.Students.FindAsync(id);
            student.Faculty = await _db.Faculty.FindAsync(student.FacultyId);
            return _mapper.Map<StudentDto>(student);
        }

        public Task<List<StudentDto>> GetAllStudenShowNameFaculty()
        {
            throw new NotImplementedException();
        }
    }
}
