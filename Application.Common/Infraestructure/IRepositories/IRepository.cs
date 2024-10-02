using Application.Common.Application.Dtos;
using Application.Common.Infrastructure.DataAccess.Entities.Base;
using System.Linq.Expressions;

namespace Application.Common.Infraestructure.IRepositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        string GetCurrentUser();

        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetListAsync();

        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, Pagination pagination);

        Task<IEnumerable<TEntity>> GetListAsync(Pagination pagination);

        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity);
    }
}
