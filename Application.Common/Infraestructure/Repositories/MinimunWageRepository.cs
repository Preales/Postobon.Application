using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.IRepositories;

namespace Application.Common.Infraestructure.Repository
{
    public class MinimunWageRepository : Repository<MinimunWage>, IMinimunWageRepository
	{
		private ApplicationDbContext _db;
		public MinimunWageRepository(ApplicationDbContext dbContext, ISystem system) : base(dbContext, system)
		{
			 _db = dbContext;
			 _system = system;
		}
	}
}
