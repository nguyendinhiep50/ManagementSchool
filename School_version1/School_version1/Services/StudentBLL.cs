﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using School_version1.Context;

using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School_version1.Services
{
    public class StudentBLL : BaseEntityService<Student, StudentAddDto>, IStudent
    {
        public StudentBLL(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<List<StudentDto>> GetAllStudentFaculty()
        {
            var students = _db.Students.ToList();
            foreach (var st in students)
                st.Faculty = _db.Faculty.Find(st.FacultyId);
            return _mapper.Map<List<StudentDto>>(students).ToList();
        }

        public async Task<List<StudentDto>> GetAllStudentsInFaculty(Guid id)
        {
            var students = await _db.Students.Where(x => x.FacultyId == id).ToListAsync();
            foreach (var st in students)
                st.Faculty = _db.Faculty.Find(id);
            return _mapper.Map<List<StudentDto>>(students).ToList();
        }

        public async Task<StudentDto> PostLoginToken(LoginDto loginAccount)
        {
            var student = await _db.Students.Where(x=>x.StudentPassword == loginAccount.PassWorld && x.StudentEmail == loginAccount.LoginEmail).FirstOrDefaultAsync();
            return _mapper.Map<StudentDto>(student);
        }
        //public async Task<StudentDto> GetLoginInfo(string Token)
        //{
            
        //} 

        public async Task<StudentDto> GetStudentFaculty(Guid id)
        {
            var student = await _db.Students.FindAsync(id);
            student.Faculty = await _db.Faculty.FindAsync(student.FacultyId);
            return _mapper.Map<StudentDto>(student);
        }

    }
}
