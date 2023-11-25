namespace CleanArch.Core.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
