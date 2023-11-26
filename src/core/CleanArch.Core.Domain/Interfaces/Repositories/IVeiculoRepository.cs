using CleanArch.Core.Domain.Entities;

namespace CleanArch.Core.Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository : IRepositoryBase<VeiculosEntity>
    {
        Task<bool> FilterAsync(DateTime startDate, DateTime endDate, string placa);

        Task<IEnumerable<VeiculosEntity>> FilterAsync(DateTime startDate, DateTime endDate);
    }
}
