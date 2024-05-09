using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FaturaBL
    {
        private readonly FaturalarDAL _faturalarDAL;
        private readonly IslemGecmisiDAL _islemGecmisiDAL;
        public FaturaBL(FaturalarDAL faturalarDAL,IslemGecmisiDAL islemGecmisiDAL)
        {
            _faturalarDAL = faturalarDAL;
            _islemGecmisiDAL = islemGecmisiDAL;
        }

        public async Task<List<Faturalar>> OdemeDurumunaGoreFaturalar(int id,Statu statu)
        {
           return await _faturalarDAL.Faturars(id, statu);
        }

        public async Task<List<Faturalar>> TumFaturalar(int id)
        {
            return await _faturalarDAL.Faturalari(id);
        }

        public async Task<Faturalar> FaturaGetir(int id)
        {
            return await _faturalarDAL.Fatura(id);
        }

        public async Task<Faturalar> FaturaGuncelle(Faturalar faturalar)
        {
            var fatura= await  _faturalarDAL.FaturaGuncelle(faturalar);
            if (fatura!= null)
            {
                fatura.Durum = Statu.Ödendi;
                fatura.HesapId = faturalar.HesapId;
                fatura.FaturaTutari = faturalar.FaturaTutari;
                fatura.SonOdemeTarihi = faturalar.SonOdemeTarihi;
                fatura.FaturaAciklamasi = faturalar.FaturaAciklamasi;             
                fatura.Hesaplar.Bakiye = (faturalar.Hesaplar.Bakiye) - (faturalar.FaturaTutari);
                
                fatura.KullaniciId=faturalar.KullaniciId;

                //işlem kaydını işlemgeçmişi tablosuna eklesin
                var yeniIslem = new IslemGecmisi
                {
                    IslemTuru = "Fatura Ödeme",
                    IslemTarihi = DateTime.Now,
                    HesapNumarasi = faturalar.Hesaplar.HesapNumarasi,
                    IslemTutari = faturalar.FaturaTutari
                };
                _islemGecmisiDAL.Ekle(yeniIslem);
                
                
                return fatura;
                
            }
            else
            {
               
                throw new Exception("Güncellenecek fatura bulunamadı.");
            }
        }
    }
}
