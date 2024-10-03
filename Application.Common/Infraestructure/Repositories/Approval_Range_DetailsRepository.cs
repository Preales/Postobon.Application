using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.IRepositories;
using Application.Common.Utility;

namespace Application.Common.Infraestructure.Repository
{
	public class Approval_Range_DetailsRepository : Repository<Approval_Range_Details>, IApproval_Range_DetailsRepository
	{
		public Approval_Range_DetailsRepository(ApplicationDbContext dbContext, ISystem system) : base(dbContext, system)
		{
			 _system = system;
		}
	}
}
