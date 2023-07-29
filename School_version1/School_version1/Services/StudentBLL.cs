using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using School_version1.Context;
using School_version1.Interface;
using School_version1.Models.DTOs;
using School_version1.Models.ObjectData;
using System.Collections.Generic;

namespace School_version1.Services
{
    public class StudentBLL:IStudent
    {
        private readonly DbContextSchool _Db;
        private readonly IMapper _mapper;

        public StudentBLL(DbContextSchool db,IMapper mapper)
        {
            _Db = db;
            _mapper = mapper;
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

        public async Task<List<StudentDto>> GetAllStudentFaculty()
        {

            var students = _Db.Students.ToList();
            foreach (var st in students) 
                st.Faculty = _Db.Faculty.Find(st.FacultyId); 
            return _mapper.Map<List<StudentDto>>(students).ToList();
        }

        public async Task<Student> GetStudent(Guid id)
        {
            return await _Db.Students.FindAsync(id);
        }

        public async Task<StudentDto> GetStudentFaculty(Guid id)
        {
            var student = await _Db.Students.FindAsync(id);
            student.Faculty = await _Db.Faculty.FindAsync(student.FacultyId);
            return _mapper.Map<StudentDto>(student);
        }
        public async Task<List<StudentDto>> GetAllStudentsInFaculty(Guid id)
        {
            var students = await _Db.Students.Where(x=>x.FacultyId ==id).ToListAsync();
            foreach (var st in students)
                st.Faculty = _Db.Faculty.Find(id);
            return _mapper.Map<List<StudentDto>>(students).ToList();
        }
        

        public async Task<Boolean> PostStudent(Student student)
        {
            try
            {
                //student.PasswordStudent = "123";
                //student.StatusStudent = true;
                //student.SchoolYear = 1;
                //student.DateComeShoool = DateTime.Now;
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
