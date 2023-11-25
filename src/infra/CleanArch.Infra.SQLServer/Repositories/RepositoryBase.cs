using CleanArch.Core.Domain.Interfaces.Repositories;
using CleanArch.Core.Shared.Exceptions;
using CleanArch.Infra.SQLServer.Context;

namespace CleanArch.Infra.SQLServer.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly EstacionamentoSqlServerContext _context;

        public RepositoryBase(EstacionamentoSqlServerContext context)
        {
            _context = context;
        }
        public async Task<T> AddASync(T entity)
        {
            try
            {
                return (await _context.Set<T>().AddAsync(entity)).Entity;
            }catch(Exception ex)
            {
                throw new InfraException(ex);
            }
        }
    }
}
