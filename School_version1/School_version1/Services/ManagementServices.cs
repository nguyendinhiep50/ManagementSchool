using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using School_version1.Repositories;

namespace School_version1.Services
{
    public class ManagementServices : BaseRepositories<Management, ManagementDto, ManagementAddDto>, IBaseRepositories<Management, ManagementDto,ManagementAddDto>
    {
        public ManagementServices(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }


    }
}
