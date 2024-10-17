using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text;

namespace Application.Common.Infraestructure.DataAccess
{
    public sealed class ApplicationDbContext : DbContext
    {
        public readonly ISystem _system;

        public DbSet<Macrosegment> Macrosegment { get; set; }
        public DbSet<Typology> Typologie { get; set; }
        public DbSet<LogExceptionInfo> LogException { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ISystem system)
            : base(options)
        {
            _system = system;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///modelBuilder.HasDefaultSchema("Negotiations");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntities = ChangeTracker.Entries<IEntityAudit>()
                .Where(e => e.State == EntityState.Added
                || e.State == EntityState.Modified
                || e.State == EntityState.Deleted)
                .ToList();
            foreach (var modifiedEntity in modifiedEntities)
            {
                var auditLog = new AuditLog
                {
                    Id = Guid.NewGuid(),
                    UserEmail = _system.User.Id,
                    EntityName = modifiedEntity.Entity.GetType().Name,
                    Action = modifiedEntity.State.ToString(),
                    Timestamp = DateTime.UtcNow,
                    Changes = GetChanges(modifiedEntity)
                };
                AuditLog.Add(auditLog);
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        private static string GetChanges(EntityEntry entity)
        {
            var changes = new StringBuilder();
            var databaseValues = entity.GetDatabaseValues();
            if (databaseValues == null) return changes.ToString();

            foreach (var property in entity.OriginalValues.Properties)
            {
                var originalValue = databaseValues[property];// entity.OriginalValues[property];
                var currentValue = entity.CurrentValues[property];
                if (!Equals(originalValue, currentValue))
                {
                    changes.AppendLine($"{property.Name}: From '{originalValue}' to '{currentValue}'");
                }
            }
            return changes.ToString();
        }
    }
}