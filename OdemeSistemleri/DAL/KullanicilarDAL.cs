using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KullanicilarDAL
    {
        private readonly ProjectContext _context;
        public KullanicilarDAL(ProjectContext context)
        {
            _context = context ;

        }

        public async Task<List<Kullanicilar>> KullaniciListesi()
        {
            List<Kullanicilar> kullanicilar = _context.Kullanici.ToList();
            return kullanicilar;
        }
    }
}
