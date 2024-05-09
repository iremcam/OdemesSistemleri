using BL;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace OdemeSistemleri.Controllers
{
    public class FaturalarController : Controller
    {
        private readonly FaturaBL _faturaBL;

        public FaturalarController(FaturaBL faturaBL)
        {
            _faturaBL = faturaBL;
        }

        public async Task<IActionResult> Index(int kullaniciId)
        {
            // Kullanıcının tüm faturalarını al
            var tumFaturalar = await _faturaBL.TumFaturalar(kullaniciId);
            return View(tumFaturalar);
        }

        public async Task<IActionResult> OdemeYap(int faturaId)
        {
            
            var fatura = await _faturaBL.FaturaGetir(faturaId);       

            await _faturaBL.FaturaGuncelle(fatura);
            await SendMessageToQueue(faturaId);
           
            return RedirectToAction("Index", new { kullaniciId = fatura.KullaniciId });
        }
        private async Task SendMessageToQueue(int faturaId)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "fatura-odeme", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    string message = $"Fatura ödeme işlemi başlatıldı: Fatura ID {faturaId}";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "fatura-odeme", basicProperties: null, body: body);
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"RabbitMQ'ye mesaj gönderilirken bir hata oluştu: {ex.Message}");
            }
        }
    }
}
