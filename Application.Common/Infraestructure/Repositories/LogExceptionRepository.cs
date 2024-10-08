﻿using Application.Common.Infraestructure.Entities;
using Application.Common.Infraestructure.IRepositories;
using Application.Common.Infraestructure.Repository;
using Application.Common.Utility;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Infraestructure.Repositories
{
    public class LogExceptionRepository : Repository<LogExceptionInfo>, ILogExceptionRepository
    {
        private DbContext _db;

        public LogExceptionRepository(DbContext dbContext, ISystem system) : base(dbContext, system)
        {
            _db = dbContext;
            _system = system;
        }
    }
}
