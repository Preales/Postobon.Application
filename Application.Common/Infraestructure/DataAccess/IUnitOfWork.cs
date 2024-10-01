using Application.Common.Infraestructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Infraestructure.DataAccess
{
    public interface IUnitOfWork
    {
        //IAuditRepository Audit { get; }
        ILogExceptionRepository Log { get; }
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
