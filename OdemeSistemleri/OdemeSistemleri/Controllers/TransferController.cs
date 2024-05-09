using BL;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace OdemeSistemleri.Controllers
{
    public class TransferController : Controller
    {

        private readonly HesaplarBL _heaplarBL;
        public TransferController(HesaplarBL heaplarBL)
        {
            _heaplarBL = heaplarBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TransferYapAction(int hesapId, int hesapId2, decimal transfermiktari)
        {
            try
            {
                await _heaplarBL.TransferYap(hesapId, hesapId2, transfermiktari);
                await SendMessageToQueue(hesapId2);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home");
            }
        }

        private async Task SendMessageToQueue(int hesapId)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "para-transferi", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    string message = $"Para Transferi işlemi başlatıldı: Transfer Hesap: {hesapId}";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "para-transferi", basicProperties: null, body: body);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"RabbitMQ'ye mesaj gönderilirken bir hata oluştu: {ex.Message}");
            }
        }
    }
}
