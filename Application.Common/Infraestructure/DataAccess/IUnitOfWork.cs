using Application.Common.Domain.Services;
using Application.Common.Infraestructure.IRepositories;

namespace Application.Common.Infraestructure.DataAccess
{
    public interface IUnitOfWork
    {
        //IAuditRepository Audit { get; }
        ILogExceptionRepository Log { get; }
        IMacrosegmentRepository MacrosegmentRepository { get; }
        ITypologyRepository TypologyRepository { get; }
        IApproval_RangeRepository Approval_RangeRepository { get; }
        IApproval_Range_DetailsRepository Approval_Range_DetailsRepository { get; }        

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
