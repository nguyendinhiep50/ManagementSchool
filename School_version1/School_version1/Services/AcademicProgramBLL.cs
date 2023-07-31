using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class AcademicProgramBLL : BaseEntityService<AcademicProgram, AcademicProgramDto> ,IAcademicProgram
    {
        public AcademicProgramBLL(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}
