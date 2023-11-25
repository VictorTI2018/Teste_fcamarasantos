namespace CleanArch.Core.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
        where T : class
    {
        Task<T> AddASync(T entity);
    }
}
