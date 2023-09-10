using School_version1.Models.DTOs;

namespace School_version1.Repositories
{
    public interface IManagementRepositories
    {
        Task<ManagementInfo> GetInfoAccount(string token);

    }
}
