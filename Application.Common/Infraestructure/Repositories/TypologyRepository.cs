using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.IRepositories;

namespace Application.Common.Infraestructure.Repository
{
    public class TypologyRepository : Repository<Typology>, ITypologyRepository
    {
        private ApplicationDbContext _db;
        public TypologyRepository(ApplicationDbContext dbContext, ISystem system) : base(dbContext, system)
        {
            _db = dbContext;
            _system = system;
        }
    }
}
