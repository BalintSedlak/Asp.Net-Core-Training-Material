namespace SharedKernel.Messaging;

public interface IEventBus
{
    Task PublishAsync<T>(T message, string queueName, CancellationToken cancellationToken = default) where T : class;
}
