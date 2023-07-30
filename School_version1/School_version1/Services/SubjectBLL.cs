using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using School_version1.Context;
using School_version1.Interface;
using School_version1.Models.DTOs;
using School_version1.Models.ObjectData;

namespace School_version1.Services
{
    public class SubjectBLL : ISubject
    {
        private readonly DbContextSchool _Db;
        private readonly IMapper _mapper;
        public SubjectBLL(DbContextSchool db, IMapper mapper)
        {
            _Db = db;
            _mapper = mapper;
        }
        public async Task<bool> DeleteSubject(Guid id)
        {
            try
            {
                var subject = await _Db.Subjects.FindAsync(id);
                _Db.Subjects.Remove(subject);
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

        public async Task<List<Subject>> GetAllSubject()
        {
            return await _Db.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubject(Guid id)
        {
            return await _Db.Subjects.FindAsync(id);
        }

        public async Task<bool> PostSubject(Subject subject)
        {
            try
            {
                var sj = _mapper.Map<Subject>(subject);
                _Db.Subjects.Add(sj);
                await _Db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<Subject> PutSubject(Guid id, Subject Subject)
        {
            _Db.Entry(Subject).State = EntityState.Modified;
            try
            {
                await _Db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return Subject;
        }
    }
}
