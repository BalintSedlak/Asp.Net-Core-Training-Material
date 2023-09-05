using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace SharedKernel.Messaging;
public sealed class RabbitMqSubscriber
{
    private readonly IConnection _connection;
    private readonly string _queueName;

    public RabbitMqSubscriber(RabbitMqConfiguration rabbitMqConfiguration, string queueName)
	{
        _queueName = queueName;

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
    }

    public void Subscribe(Action<object> action)
    {
        using (var channel = _connection.CreateModel())
        {
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                action.Invoke(message);
            };

            channel.QueueDeclare(queue: _queueName,
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            channel.BasicConsume(queue: _queueName,
                    autoAck: true,
                    consumer: consumer);
        }
    }
}
