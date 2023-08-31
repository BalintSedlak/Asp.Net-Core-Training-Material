using MassTransit;
using SharedKernel.Messaging;
using Subscriber.Repository;

namespace Subscriber.Messaging;

public class OrderConsumer : IConsumer<OrderCreated>
{
    private readonly IRepository<OrderCreated> _repository;

    public OrderConsumer(IRepository<OrderCreated> repository)
    {
        _repository = repository;
    }

    public Task Consume(ConsumeContext<OrderCreated> context)
    {
        _repository.Add(context.Message);

        return Task.CompletedTask;
    }
}
