namespace Pickles.Domain.Infrastructure;

public interface IMessagingService
{
    Task Publish<T>(T message);
    Task PublishMany<T>(IEnumerable<T> messages);
    Task Send<T>(string destination, T message);
}