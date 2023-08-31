using MassTransit;

namespace SharedKernel.Messaging;
public sealed class EventBus : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventBus(IPublishEndpoint publishEndpoint)
	{
        _publishEndpoint = publishEndpoint;
    }

    public Task PublishAsync<T>(T message, string queueName, CancellationToken cancellationToken = default)
        where T : class
    {
        return _publishEndpoint.Publish<T>
            (message, 
            context => 
            {
                context.DestinationAddress = new Uri($"queue:{queueName}");
            }, 
            cancellationToken);
    }
}
