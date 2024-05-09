using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Hesaplar : Base
    {
        public ICollection<IslemGecmisi> IslemGecmis { get; set; }
        public ICollection<Faturalar> Faturalar { get; set; }
        public int HesapNumarasi { get; set; }
        public Kullanicilar Kullanicilar { get; set; }
        public int KullaniciId { get; set; }
        public decimal Bakiye { get; set; }
        public HesapTurleri HesapTuru { get; set; }
    }
}
