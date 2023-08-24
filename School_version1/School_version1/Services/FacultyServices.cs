using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    
    public class FacultyServices : BaseEntityService<Faculty, FacultyDto,FacultyAddDto> ,IFaculty
    {
        public FacultyServices(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}
