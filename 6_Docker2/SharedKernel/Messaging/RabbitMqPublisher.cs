using RabbitMQ.Client;
using System.Text;

namespace SharedKernel.Messaging;
public sealed class RabbitMqPublisher
{
    private readonly IConnection _connection;
    private readonly string _queueName;

    public RabbitMqPublisher(RabbitMqConfiguration rabbitMqConfiguration, string queueName)
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
        _queueName = queueName;
    }

    public void Publish(string message)
    {
        using (var channel = _connection.CreateModel())
        {
            channel.QueueDeclare(queue: _queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
