namespace CleanArch.Core.Services.UseCases.Interfaces
{
    public interface ICadastrarUseCase <T, TResponse>
        where T : class
        where TResponse : class
    {
        Task<TResponse> ExecuteAsync(T obj);
    }
}
