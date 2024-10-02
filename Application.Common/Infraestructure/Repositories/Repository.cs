using Application.Common.Domain.Dtos;
using Application.Common.Infraestructure.Entities.Base;
using Application.Common.Infraestructure.IRepositories;
using Application.Common.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Common.Infraestructure.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel : BaseEntity
    {
        protected readonly DbSet<TModel> ModelDbSets;
        protected ISystem _system;
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext, ISystem system)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException();
            ModelDbSets = _dbContext.Set<TModel>();
            _system = system;
        }

        public TModel Add(TModel entity)
        {
            AssignAuditField(entity);
            return ModelDbSets.Add(entity).Entity;
        }

        private void AssignAuditField(TModel entity)
        {
            //entity.Id = (entity.Id == Guid.Empty) ? Guid.NewGuid() : entity.Id;            
            entity.CreationUser = !string.IsNullOrEmpty(entity.CreationUser) ? entity.CreationUser : GetCurrentUser();
            entity.CreationDate = DateExt.getDate();
            entity.Deleted = false;
        }

        public async Task<TModel> AddAsync(TModel entity)
        {
            AssignAuditField(entity);
            await Task.Run(() => _dbContext.Entry(entity).State = EntityState.Added);
            return entity;
        }

        public void AddRange(IEnumerable<TModel> entities)
        {
            foreach (var entity in entities)
            {
                AssignAuditField(entity);
            }

            ModelDbSets.AddRange(entities);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<TModel> GetAsync(Expression<Func<TModel, bool>> predicate)
        {
            //Expression<Func<TModel, bool>> exp = x => x.TenantId == _system.TenantId;
            //var combined = Expression.Lambda<Func<TModel, bool>>(Expression.AndAlso(exp.Body, predicate.Body), exp.Parameters);
            //var lamda = predicate.AndAlso(exp);
            return await ModelDbSets.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public string GetCurrentUser()
        {
            return (_system.User?.Id != null) ? _system.User.Id : "system";//CONSTANT_USER.AdministratorUser;
        }

        public async Task<IEnumerable<TModel>> GetListAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await ModelDbSets.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetListAsync(Expression<Func<TModel, bool>> predicate, Pagination pagination)
        {
            return await ModelDbSets.AsNoTracking().Where(predicate).Paginate(pagination).ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetListAsync()
        {
            return await ModelDbSets.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetListAsync(Pagination pagination)
        {
            return await ModelDbSets.AsNoTracking().Paginate(pagination).ToListAsync();
        }

        public async Task<bool> Any(Expression<Func<TModel, bool>> predicate)
        {
            return await ModelDbSets.AnyAsync(predicate);
        }

        public IQueryable<TModel> Queryable(Expression<Func<TModel, bool>> predicate)
        {
            return ModelDbSets.Where(predicate);
        }

        public void Remove(TModel entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached) ModelDbSets.Attach(entity);

            ModelDbSets.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TModel> entities)
        {
            foreach (var entity in entities)
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached) ModelDbSets.Attach(entity);

                ModelDbSets.Remove(entity);
            }
        }

        public void Update(TModel entity)
        {
            entity.ModificationUser = GetCurrentUser();
            entity.ModificationDate = DateExt.getDate();
            ModelDbSets.Attach(entity);
        }

        public async Task UpdateAsync(TModel entity)
        {
            entity.ModificationUser = GetCurrentUser();
            entity.ModificationDate = DateExt.getDate();
            await Task.Run(() => _dbContext.Entry(entity).State = EntityState.Modified);
        }
    }
}