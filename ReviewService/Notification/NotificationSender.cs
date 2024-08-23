using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using ReviewService.Configuration;
using System.Text;
using IModel = RabbitMQ.Client.IModel;

namespace ReviewService.Notification;

public class NotificationSender : INotificationSender, IDisposable
{
    private readonly RabbitMQConfig config;
    private readonly IConnection connection;
    private readonly IModel channel;

    public NotificationSender(IOptions<RabbitMQConfig> options)
    {
        this.config = options.Value;

        var factory = new ConnectionFactory
        {
            HostName = this.config.HostName,
            UserName = this.config.UserName,
            Password = this.config.Password
        };

        this.connection = factory.CreateConnection();
        this.channel = connection.CreateModel();

        channel.QueueDeclare(queue: this.config.QueueName,
                              durable: true,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);
    }

    public void Send(NotificationPayload payload)
    {
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload));

        channel.BasicPublish(exchange: "",
                              routingKey: config.QueueName,
                              basicProperties: null,
                              body: body);
    }

    public void Dispose()
    {
        channel?.Dispose();
        connection?.Dispose();
    }
}
