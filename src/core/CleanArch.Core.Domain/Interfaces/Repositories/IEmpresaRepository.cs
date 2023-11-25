using CleanArch.Core.Domain.Entities;

namespace CleanArch.Core.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository : IRepositoryBase<EmpresaEntity>
    {
        Task<EmpresaEntity?> GetOne(int id);
        Task<IEnumerable<EmpresaEntity>> GetAllAsync();
    }
}
