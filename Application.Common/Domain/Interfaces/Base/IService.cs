using Application.Common.Domain.Dtos;

namespace Application.Common.Domain.Interfaces.Base
{
    public interface IService<TEntity, TEntityId> where TEntity : class
    {
        Task<TEntity> Create(TEntity item);
        Task<bool> Delete(TEntityId id);
        Task<bool> DeleteLogic(TEntityId id);
        Task<TEntity> Get(TEntityId id);
        Task<IEnumerable<TEntity>> List();
        Task<IEnumerable<TEntity>> List(Pagination pagination);
        Task<TEntity> Update(TEntity item);
    }
}
