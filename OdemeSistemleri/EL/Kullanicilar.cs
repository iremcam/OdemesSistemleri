using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Kullanicilar : Base
    {
        public ICollection<Faturalar> Faturalar { get; set; }
        public ICollection<Hesaplar> Hesaplar { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Adres { get; set; }

    }
}
