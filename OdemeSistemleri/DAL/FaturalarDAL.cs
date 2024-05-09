using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FaturalarDAL
    {
        private readonly ProjectContext _projectContext;
        public FaturalarDAL(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        //kullanıcıya ait tüm faturalar
        public async Task<List<Faturalar>> Faturalari(int id)
        {
            List<Faturalar> faturalars=_projectContext.Faturalar.Where(a=>a.KullaniciId==id).ToList();
            return faturalars;

        }

        //durumuna göre faturalar
        public async Task<List<Faturalar>> Faturars(int id, Statu statu)
        {
            List<Faturalar> faturalars = _projectContext.Faturalar.Where(a=>a.KullaniciId==id  && a.Durum==statu).ToList();
            return faturalars;
        }
        public async Task<Faturalar> Fatura(int id)
        {
            

                return await _projectContext.Faturalar.FindAsync(id);
        }

        public async Task<Faturalar> FaturaGuncelle(Faturalar faturalar)
        {
           var fatura= _projectContext.Faturalar.FindAsync(faturalar);
            return await fatura;

        }
    }
}
