using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.IRepositories;

namespace Application.Common.Infraestructure.Repository
{
    public class MacrosegmentRepository : Repository<Macrosegment>, IMacrosegmentRepository
    {

        public MacrosegmentRepository(ApplicationDbContext dbContext, ISystem system) : base(dbContext, system)
        {

            _system = system;
        }
    }
}
