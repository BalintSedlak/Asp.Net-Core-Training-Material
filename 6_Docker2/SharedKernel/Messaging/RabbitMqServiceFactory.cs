namespace SharedKernel.Messaging;

public class RabbitMqServiceFactory
{
    private readonly RabbitMqConfiguration _rabbitMqConfiguration;
    Dictionary<string, RabbitMqPublisher> _publishers;
    Dictionary<string, RabbitMqSubscriber> _subscribers;

    public RabbitMqServiceFactory(RabbitMqConfiguration rabbitMqConfiguration)
    {
        _rabbitMqConfiguration = rabbitMqConfiguration;

        _publishers = new Dictionary<string, RabbitMqPublisher>();
        _subscribers = new Dictionary<string, RabbitMqSubscriber>();
    }

    public RabbitMqPublisher GetPublisher(string queueName)
    {
        if (!_publishers.ContainsKey(queueName))
        {
            _publishers.Add(queueName, new RabbitMqPublisher(_rabbitMqConfiguration, queueName));
        }

        return _publishers[queueName];
    }

    public RabbitMqSubscriber GetSubscriber(string queueName)
    {
        if (!_subscribers.ContainsKey(queueName))
        {
            _subscribers.Add(queueName, new RabbitMqSubscriber(_rabbitMqConfiguration, queueName));
        }

        return _subscribers[queueName];
    }
}
