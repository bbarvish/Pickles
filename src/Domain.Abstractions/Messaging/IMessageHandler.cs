namespace Pickles.Domain.Messaging;

public interface IMessageHandler<in T>
{
    public Task Handle(T message);
}