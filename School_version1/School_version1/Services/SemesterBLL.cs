using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class SemesterBLL :ISemesters
    {
        private readonly DbContextSchool _Db;
        private readonly IMapper _mapper;
        public SemesterBLL(DbContextSchool db, IMapper mapper)
        {
            _Db = db;
            _mapper = mapper;
        }

        public async Task<bool> DeleteSemester(Guid id)
        {
            try
            {
                var Semester = await _Db.Semesters.FindAsync(id);
                _Db.Semesters.Remove(Semester);
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

        public async Task<List<Semester>> GetAllSemester()
        {
            return await _Db.Semesters.ToListAsync();
        }

        public async Task<Semester> GetSemester(Guid id)
        {
            return await _Db.Semesters.FindAsync(id);
        }

        public async Task<bool> PostSemester(SemesterDto semesterDto)
        {
            try
            {
                var sj = _mapper.Map<Semester>(semesterDto);
                sj.SemesterStatus = true;
                _Db.Semesters.Add(sj);
                await _Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<Semester> PutSemester(Guid id, Semester semester)
        {
            _Db.Entry(semester).State = EntityState.Modified;
            try
            {
                await _Db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return semester;
        }
    }
}
