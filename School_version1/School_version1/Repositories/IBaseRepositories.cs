using School_version1.Entities;

namespace School_version1.Repositories
{
    public interface IBaseRepositories<T, TDto> where T : class where TDto : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<Guid> Delete(Guid id);
        Task<TDto> Post(TDto dto);
        Task<T> Put(Guid id, T objectT);
    }
}
