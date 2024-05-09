using EL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class HesaplarDAL
    {
        private readonly ProjectContext _context;
        
        public HesaplarDAL(ProjectContext context)
        {
            _context = context ;

        }
        public async Task<List<Hesaplar>> HesaplarLis()
        {
            List<Hesaplar> hesaplar=_context.HesapBilgileri.ToList();
            return hesaplar;
        }
        public async Task<List<Hesaplar>> TuruneGoreHesaplar(int id)
        {
            List<Hesaplar> hesaplar=_context.HesapBilgileri.Where(a=>a.KullaniciId==id).ToList();
            return hesaplar;

        }
        public async Task<IQueryable<Hesaplar>> HesapGetir(int id)
        {
            var hesap = _context.HesapBilgileri.Where(a => a.Id == id);
            return hesap;
        }
        public Hesaplar HesapNumarasiGetir(int hesapNumarasi)
        {
            return _context.HesapBilgileri.FirstOrDefault(h => h.HesapNumarasi == hesapNumarasi);
        }

        public void Update(Hesaplar hesap)
        {
            _context.HesapBilgileri.Update(hesap);
            _context.SaveChanges();
        }
    }
}
