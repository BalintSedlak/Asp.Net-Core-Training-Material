using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;

namespace SharedKernel.Messaging;
public sealed class RabbitMqPublisher
{
    private readonly IConnection _connection;

    public RabbitMqPublisher(RabbitMqConfiguration rabbitMqConfiguration)
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
    }

    public void Publish(string message)
    {
        using (var channel = _connection.CreateModel())
        {
            channel.QueueDeclare(queue: "myQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",
                                 routingKey: "myQueue",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
