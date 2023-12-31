using Pickles.Domain.Events;
using Pickles.Domain.Messaging;

namespace Pickles.Domain.MessageHandlers;

public class UserCreatedHandler : IMessageHandler<UserCreated>
{
    public Task Handle(UserCreated message)
    {
        Console.WriteLine($"Handling {nameof(UserCreated)} with payload {message.ToJson()}");
        return Task.CompletedTask;
    }
}