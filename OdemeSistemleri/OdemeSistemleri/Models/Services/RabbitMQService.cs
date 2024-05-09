namespace OdemeSistemleri.Models.Services
{
    public class RabbitMQService
    {
        private readonly FaturaOdemeConsumer _faturaOdemeConsumer;

        public RabbitMQService(FaturaOdemeConsumer faturaOdemeConsumer)
        {
            _faturaOdemeConsumer = faturaOdemeConsumer;
        }

        public void StartConsuming()
        {
            // RabbitMQ kuyruğunu dinlemeye başla
            _faturaOdemeConsumer.Consume();
        }
    }
}
