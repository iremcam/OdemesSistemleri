using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Faturalar : Base


    {
        public Hesaplar Hesaplar { get; set; }
        public IslemGecmisi IslemGecmisi { get; set; }  
        public int HesapId { get; set; }
        public decimal FaturaTutari { get; set; }
        public DateTime SonOdemeTarihi { get; set; }
        public string FaturaAciklamasi { get; set; }
        public Statu Durum { get; set; }
        public int KullaniciId { get; set; }
    }
}
