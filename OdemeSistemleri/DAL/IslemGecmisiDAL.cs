using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IslemGecmisiDAL
    {
        private readonly ProjectContext _projectContext;
        public IslemGecmisiDAL(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        //müşteriye ait işlem geçmişi
        public async Task<List<IslemGecmisi>> IslemGecmisi(int hesap)
        {
            List<IslemGecmisi> islemgecmisi = _projectContext.IslemGecmisi.Where(a => a.Hesaplar.Id == hesap).ToList();
            return islemgecmisi;
        }

        //işlem türüne göre yapılan işlemleri sırala
        public async Task<List<IslemGecmisi>> IslemTuruneGore(int hesap, string tur)
        {
            List<IslemGecmisi> islemler = _projectContext.IslemGecmisi.Where(a => a.Hesaplar.Id == hesap && a.IslemTuru == tur).ToList();
            return islemler;
        }

        public async Task  Ekle(IslemGecmisi islemGecmisi)
        {
            _projectContext.IslemGecmisi.Add(islemGecmisi);
            await  _projectContext.SaveChangesAsync();
          
        }
    }
}
