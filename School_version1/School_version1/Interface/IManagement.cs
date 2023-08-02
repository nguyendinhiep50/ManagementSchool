using School_version1.Entities;
using School_version1.Models.DTOs;
using School_version1.Repositories;

namespace School_version1.Interface
{
    public interface IManagement : IBaseRepositories<Management, ManagementDto>
    {
    }
}
