using BL;
using Microsoft.AspNetCore.Mvc;

namespace OdemeSistemleri.Controllers
{
    public class IslemGecmisiController : Controller
    {
        private readonly IslemGecmisiBL _islemGecmisiBL;
        public IslemGecmisiController(IslemGecmisiBL islemGecmisiBL)
        {
            _islemGecmisiBL = islemGecmisiBL;

        }
        //kullanıcıya ait tüm işlem geçmişleri
        public async Task<IActionResult> Index(int hesapId)
        {
            var tumIslemler = await _islemGecmisiBL.IslemGecmisleri(hesapId);
            return View(tumIslemler);
           
        }


    }
}
