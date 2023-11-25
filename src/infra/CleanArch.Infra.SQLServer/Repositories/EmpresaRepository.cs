using CleanArch.Core.Domain.Entities;
using CleanArch.Core.Domain.Interfaces.Repositories;
using CleanArch.Infra.SQLServer.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.SQLServer.Repositories
{
    public class EmpresaRepository : RepositoryBase<EmpresaEntity> , IEmpresaRepository
    {
        private readonly EstacionamentoSqlServerContext _context;
        public EmpresaRepository(EstacionamentoSqlServerContext context) : base(context) { 
            _context = context;
        }

        public async Task<EmpresaEntity?> GetOne(int id) => await _context.Set<EmpresaEntity>()
            .Include(x => x.Endereco)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<IEnumerable<EmpresaEntity>> GetAllAsync()
        {
            return await _context.Set<EmpresaEntity>()
                .Include(x => x.Endereco)
                .AsNoTracking()
                .ToListAsync();

        }


    }
}
