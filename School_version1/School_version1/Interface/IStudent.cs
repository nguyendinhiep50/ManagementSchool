﻿using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface IStudent : IEntityService<Student,StudentDto,StudentAddDto>
    {
        Task<List<StudentDto>> GetAllStudentFaculty(int page,int size); 
        Task<StudentDto> GetStudentFaculty(Guid id);
        Task<List<StudentDto>> GetAllStudentsInFaculty(Guid id);
        Task<StudentInfo> GetInfoAccountStudent(string token);
        Task<List<SubjectGradesAddDto>> GetTakeCourseScores(Guid idAccount);
        Task<bool> PostManyStudent(List<StudentAddDto> listStudent);

    }
}
