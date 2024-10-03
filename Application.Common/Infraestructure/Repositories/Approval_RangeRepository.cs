using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.IRepositories;
using Application.Common.Utility;

namespace Application.Common.Infraestructure.Repository
{
	public class Approval_RangeRepository : Repository<Approval_Range>, IApproval_RangeRepository
	{
		public Approval_RangeRepository(ApplicationDbContext dbContext, ISystem system) : base(dbContext, system)
		{
			 _system = system;
		}
	}
}
