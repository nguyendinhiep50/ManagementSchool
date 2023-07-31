﻿using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface ITeacher
    {
        Task<List<Teacher>> GetAllTeacher();
        Task<Teacher> GetTeacher(Guid id);
        Task<Boolean> DeleteTeacher(Guid id);
        Task<bool> PostTeacher(TeacherDto TeacherDto);
        Task<Teacher> PutTeacher(Guid id, Teacher teacher);
    }
}
