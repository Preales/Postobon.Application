using Application.Common.Infraestructure.IRepositories;
using Application.Common.Infraestructure.Repositories;
using Application.Common.Infraestructure.Repository;
using Application.Common.Utility.ExceptionResources;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Application.Common.Infraestructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _dbContext;
        public ISystem _system;
        public IMemoryCache _memoryCache;
        public IConfiguration _configuration;

        //private IAuditRepository _audit { get; set; }
        //public IAuditRepository Audit
        //{
        //    get
        //    {
        //        return _audit = _audit ?? new AuditRepository(_dbContext, _system);
        //    }
        //}

        private ILogExceptionRepository _log { get; set; }
        public ILogExceptionRepository Log
        {
            get
            {
                return _log = _log ?? new LogExceptionRepository(_dbContext, _system);
            }
        }

        private IMacrosegmentRepository _macrosegmentRepository { get; set; }

        public IMacrosegmentRepository MacrosegmentRepository
        {
            get
            {
                return _macrosegmentRepository = _macrosegmentRepository ?? new MacrosegmentRepository(_dbContext, _system);
            }
        }

        private ITypologyRepository _typologyRepository { get; set; }

        public ITypologyRepository TypologyRepository
        {
            get
            {
                return _typologyRepository = _typologyRepository ?? new TypologyRepository(_dbContext, _system);
            }
        }


        public UnitOfWork(ApplicationDbContext dbContext,
                         ISystem system,
                         IMemoryCache memoryCache,
                         IConfiguration configuration)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException();
            _system = system ?? throw new ArgumentNullException();
            _memoryCache = memoryCache ?? throw new ArgumentNullException();
            _configuration = configuration ?? throw new ArgumentNullException();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _dbContext.SaveChangesAsync();
                if (result == 0)
                    throw new AppException("No se pudo realizar el commit sobre la DB");
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
