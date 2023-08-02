using AutoMapper;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using School_version1.Repositories;

namespace School_version1.Services
{
    public class ManagementBLL : BaseRepositories<Management, ManagementDto>, IBaseRepositories<Management, ManagementDto>
    {
        public ManagementBLL(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}
