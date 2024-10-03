using Application.Common.Infraestructure.IRepositories;

namespace Application.Common.Infraestructure.DataAccess
{
    public interface IUnitOfWork
    {
        //IAuditRepository Audit { get; }
        ILogExceptionRepository Log { get; }
        IMacrosegmentRepository MacrosegmentRepository { get; }
        ITypologyRepository TypologyRepository { get; }
        IMinimunWageRepository MinimunWageRepository { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
