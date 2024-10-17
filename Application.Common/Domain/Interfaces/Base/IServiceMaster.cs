using Application.Common.Domain.Dtos;

namespace Application.Common.Domain.Interfaces.Base
{
    public interface IServiceMaster<TEntity, TEntityId> where TEntity : class
    {
        Task<TEntity> Create(TEntity item);
        Task<bool> Delete(TEntityId code);
        Task<bool> DeleteLogic(TEntityId code);
        Task<TEntity> Get(TEntityId code);
        Task<IEnumerable<TEntity>> List();
        Task<IEnumerable<TEntity>> List(Pagination pagination);
        Task<TEntity> Update(TEntity item);
    }
}
