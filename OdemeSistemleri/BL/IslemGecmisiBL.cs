using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class IslemGecmisiBL
    {
        private readonly IslemGecmisiDAL _islemGecmisiDAL;

        public IslemGecmisiBL(IslemGecmisiDAL islemGecmisiDAL)
        {
            _islemGecmisiDAL = islemGecmisiDAL;
        }
        public async Task<List<IslemGecmisi>> IslemGecmisleri(int id)
        {
            return await _islemGecmisiDAL.IslemGecmisi(id);
        }
        public async Task<List<IslemGecmisi>> IslemTuruneGoreGecmis(int id, string tur)
        {
            return await _islemGecmisiDAL.IslemTuruneGore(id, tur);
        }
    }
}
