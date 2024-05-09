using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class IslemGecmisi : Base
    {
        public Hesaplar Hesaplar { get; set; }
        public int HesapNumarasi { get; set; }
        public int HesapNumarasi2 { get; set; }
        public DateTime IslemTarihi { get; set; }
        public string IslemTuru { get; set; }
        public decimal IslemTutari { get; set; }
    }
}
