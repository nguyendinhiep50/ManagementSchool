using School_version1.Entities;

namespace School_version1.Interface
{
    public interface IFaculty
    {
        Task<List<Faculty>> GetAllFaculty();
        Task<Faculty> GetFaculty(Guid id);
        Task<Boolean> DeleteFaculty(Guid id);
        Task<bool> PostFaculty(Faculty faculty);
        Task<Faculty> PutFaculty(Guid id, Faculty faculty);
    }
}
