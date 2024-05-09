using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class KullaniciBL
    {
        private readonly KullanicilarDAL _kullaniciDal;
        public KullaniciBL(KullanicilarDAL kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }
        public async Task<List<Kullanicilar>> GetKullanicisAsync()
        {
            return await _kullaniciDal.KullaniciListesi();
        }
    }
}
