using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.IRepositories;

namespace Application.Common.Infraestructure.Repository
{
    public class MacrosegmentRepository : Repository<Macrosegment>, IMacrosegmentRepository
    {
        private ApplicationDbContext _db;
        public MacrosegmentRepository(ApplicationDbContext dbContext, ISystem system) : base(dbContext, system)
        {
            _db = dbContext;
            _system = system;
        }
    }
}
