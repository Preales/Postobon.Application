using Application.Common.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Infraestructure.DataAccess
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Macrosegment> Macrosegment { get; set; }
        public DbSet<Typology> Typologie { get; set; }
        public DbSet<LogExceptionInfo> LogException { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///modelBuilder.HasDefaultSchema("Negotiations");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}