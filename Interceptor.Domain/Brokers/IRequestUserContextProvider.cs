namespace Interceptor.Domain.Brokers;

public interface IRequestUserContextProvider
{
    public Guid GetUserIdAsync(CancellationToken cancellationToken = default);
}