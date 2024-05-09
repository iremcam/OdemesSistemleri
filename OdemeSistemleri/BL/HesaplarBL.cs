using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public  class HesaplarBL
    {
        public readonly HesaplarDAL _hesaplarDAL;
        private readonly IslemGecmisiDAL _islemGecmisiDAL;
        public HesaplarBL(HesaplarDAL hesaplarDAL, IslemGecmisiDAL islemGecmisiDAL)
        {
            _hesaplarDAL = hesaplarDAL;
            _islemGecmisiDAL = islemGecmisiDAL;
        }
        public async Task<List<Hesaplar>> GetHesaplarAsync()
        {
            return await _hesaplarDAL.HesaplarLis();
        }

        public async Task<IQueryable<Hesaplar>> HesapGetir(int id)
        {
            return await _hesaplarDAL.HesapGetir(id);
        }

        public async Task<bool> TransferYap(int gonderenHesapNumarasi, int alanHesapNumarasi, decimal transferMiktari)
        {
            var gonderenHesap = _hesaplarDAL.HesapNumarasiGetir(gonderenHesapNumarasi);
            var alanHesap = _hesaplarDAL.HesapNumarasiGetir(alanHesapNumarasi);

            if (gonderenHesap == null || alanHesap == null)
                return false;

            if (gonderenHesap.Bakiye < transferMiktari)
                return false;

            gonderenHesap.Bakiye -= transferMiktari;
            alanHesap.Bakiye += transferMiktari;

            _hesaplarDAL.Update(gonderenHesap);
            _hesaplarDAL.Update(alanHesap);
            var yeniIslem = new IslemGecmisi
            {
                IslemTuru = "Para Transferi",
                IslemTarihi = DateTime.Now,
                HesapNumarasi = gonderenHesap.HesapNumarasi,
                HesapNumarasi2 = alanHesap.HesapNumarasi,
                IslemTutari = transferMiktari,
            };
            _islemGecmisiDAL.Ekle(yeniIslem);

            return true;
        }

    }
}
