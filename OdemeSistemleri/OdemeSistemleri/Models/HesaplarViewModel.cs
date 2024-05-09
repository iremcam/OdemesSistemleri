using EL;

namespace OdemeSistemleri.Models
{
    public class HesaplarViewModel
    {
        public int Id { get; set; }
        public List<IslemGecmisi> IslemGecmis { get; set; }
        public List<Faturalar> Faturalar { get; set; }
        public int HesapNumarasi { get; set; }
        public List<Kullanicilar> Kullanicilar { get; set; }
        public int KullaniciId { get; set; }
        
    }
}
