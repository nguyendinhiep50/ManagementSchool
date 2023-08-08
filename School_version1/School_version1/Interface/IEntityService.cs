namespace School_version1.Interface
{
    public interface IEntityService<T, TDto> where T : class where TDto : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Post(TDto dto);
        Task<T> Put(Guid id, T objectT);
    }
}
