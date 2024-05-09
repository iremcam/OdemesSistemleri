using EL;

namespace OdemeSistemleri.Models
{
    public class FaturalarViewModel
    {
        public int Id { get; set; }
        public List<Hesaplar> Hesaplar { get; set; }
        public int HesapId { get; set; }
    }
}
