using CleanArch.Core.Domain.Interfaces.Repositories;

namespace CleanArch.Infra.SQLServer.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EstacionamentoSqlServerContext _context;
        private bool _disposed;

        public UnitOfWork(EstacionamentoSqlServerContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
