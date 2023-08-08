using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class AcademicProgramBLL : BaseEntityService<AcademicProgram, AcademicProgramDto,AcademicProgramAddDto> ,IAcademicProgram
    {
        public AcademicProgramBLL(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<List<AcademicProgramSPDto>> GetProgramLearn()
        {
            Guid id = Guid.NewGuid();
            var program = await _db.AcademicPrograms
                .Include(p => p.Faculty)
                .Include(x => x.Subject).ToListAsync();
            var result = _mapper.Map<List<AcademicProgramSPDto>>(program).ToList();
            return  result;
        }
        public async Task<List<AcademicProgramSPDto>> GetProgramLearnFaculty(Guid FacultyId)
        {
            Guid id = Guid.NewGuid();
            var program = await _db.AcademicPrograms
                .Include(p => p.Faculty)
                .Include(x => x.Subject)
                .Where(x=>x.FacultyId == FacultyId && x.TimeEndAcademicProgram > DateTime.Now)
                .ToListAsync();
            var result = _mapper.Map<List<AcademicProgramSPDto>>(program).ToList();
            return result;
        }

    }
}
