using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace School_version1.Interface
{
    public interface IEntityService<T,TDto, TAddOrUpdateDto> where T : class where TDto : class where TAddOrUpdateDto : class
    {
        Task<List<TDto>> GetAll(int pages);
        Task<int> GetAllCount();
        Task<TDto> Get(Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Post(TAddOrUpdateDto dto);
        Task<bool> Put(Guid id, TDto objectT);
    }
}
