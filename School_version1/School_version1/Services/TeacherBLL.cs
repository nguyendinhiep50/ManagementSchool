using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class TeacherBLL : BaseEntityService<Teacher, TeacherDto,TeacherAddDto> ,ITeacher
    {
        public TeacherBLL(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }
        public async Task<TeacherDto> PostLoginToken(LoginAddDto loginAccount)
        {
            try
            {
                var teacher = await _db.Teachers.Where(x => x.TeacherPassword == loginAccount.PassWorld && x.TeacherEmail == loginAccount.LoginEmail).FirstOrDefaultAsync();
                return _mapper.Map<TeacherDto>(teacher);
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
