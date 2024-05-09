using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace OdemeSistemleri.Models.Services
{
    public class FaturaOdemeConsumer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public FaturaOdemeConsumer()
        {

            var factory = new ConnectionFactory() { HostName = "localhost", Port = 15672, UserName = "admin", Password = "admin4736" };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.QueueDeclare(queue: "fatura-odeme", durable: false, exclusive: false, autoDelete: false, arguments: null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while creating connection: {ex.Message}");
                throw;
            }
        }

        public void Consume()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);

              
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume(queue: "fatura-odeme", autoAck: false, consumer: consumer);
        }

        
    }
}
