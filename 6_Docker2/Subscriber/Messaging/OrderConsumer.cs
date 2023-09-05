using MassTransit;
using SharedKernel.Messaging;
using Subscriber.Repository;
using System.Text.Json;

namespace Subscriber.Messaging;

public class OrderConsumer
{
    private readonly RabbitMqSubscriber _rabbitMqSubscriber;
    private readonly IRepository<OrderCreated> _repository;

    public OrderConsumer(RabbitMqSubscriber rabbitMqSubscriber, IRepository<OrderCreated> repository)
    {
        _rabbitMqSubscriber = rabbitMqSubscriber;
        _repository = repository;

        _rabbitMqSubscriber.Subscribe(Consume);
    }

    public void Consume(object model)
    {
        if (model is string modelAsString)
        {
            OrderCreated order = JsonSerializer.Deserialize<OrderCreated>(modelAsString);
            _repository.Add(order);
        }
        else
        {
            throw new Exception();
        }
    }
}
