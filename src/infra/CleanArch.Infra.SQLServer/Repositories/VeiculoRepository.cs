using CleanArch.Core.Domain.Entities;
using CleanArch.Core.Domain.Interfaces.Repositories;
using CleanArch.Infra.SQLServer.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.SQLServer.Repositories
{
    public class VeiculoRepository : RepositoryBase<VeiculosEntity>, IVeiculoRepository
    {
        private readonly EstacionamentoSqlServerContext _context;
        public VeiculoRepository(EstacionamentoSqlServerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> FilterAsync(DateTime startDate, DateTime endDate, string placa) => await _context.Set<VeiculosEntity>()
            .AsNoTracking()
            .AnyAsync(x => (x.Created.Value.Date >= startDate.Date && x.Created.Value.Date <= endDate) && x.Placa == placa);

        public Task<IEnumerable<VeiculosEntity>> FilterAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
