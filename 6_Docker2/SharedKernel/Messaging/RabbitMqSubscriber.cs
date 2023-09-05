using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;
using static MassTransit.Logging.OperationName;

namespace SharedKernel.Messaging;
public sealed class RabbitMqSubscriber
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqSubscriber(RabbitMqConfiguration rabbitMqConfiguration)
	{
        ConnectionFactory connectionFactory = new ConnectionFactory()
        {
            HostName = rabbitMqConfiguration.Host,
            Port = rabbitMqConfiguration.Port,
            UserName = rabbitMqConfiguration.UserName,
            Password = rabbitMqConfiguration.Password,
            VirtualHost = "/",
        };

        connectionFactory.DispatchConsumersAsync = true;
        _connection = connectionFactory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "myQueue",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

       
    }

    public void Subscribe(Action<object> action)
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            action.Invoke(message);
        };

        _channel.BasicConsume(queue: "myQueue",
                    autoAck: true,
                    consumer: consumer);
    }
}
