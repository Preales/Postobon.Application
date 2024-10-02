using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.IRepositories;

namespace Application.Common.Infraestructure.Repository
{
    public class TypologyRepository : Repository<Typology>, ITypologyRepository
    {
        public TypologyRepository(ApplicationDbContext dbContext, ISystem system) : base(dbContext, system)
        {
        }
    }
}
