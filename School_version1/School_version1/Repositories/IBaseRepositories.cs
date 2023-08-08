using School_version1.Entities;

namespace School_version1.Repositories
{
    public interface IBaseRepositories<T, TDto,TAddOrUpdateDto> where T : class where TDto : class where TAddOrUpdateDto : class
    {
        Task<List<TDto>> GetAll();
        Task<TDto> Get(Guid id);
        Task<Guid> Delete(Guid id);
        Task<TAddOrUpdateDto> Post(TAddOrUpdateDto dto);
        Task<TDto> Put(Guid id, TDto objectT);
    }
}
