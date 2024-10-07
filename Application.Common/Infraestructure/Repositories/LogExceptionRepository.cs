using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.IRepositories;
using Application.Common.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Infraestructure.Repositories
{
    public class LogExceptionRepository : Repository<LogExceptionInfo>, ILogExceptionRepository
    {
        private ApplicationDbContext _db;

        public LogExceptionRepository(ApplicationDbContext dbContext, ISystem system) : base(dbContext, system)
        {
            _db = dbContext;
            _system = system;
        }
    }
}
