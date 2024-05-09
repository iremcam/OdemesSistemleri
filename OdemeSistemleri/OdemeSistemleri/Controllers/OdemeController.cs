using Microsoft.AspNetCore.Mvc;

namespace OdemeSistemleri.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class OdemeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OdemeIslemleri()
        {
            return View();
        }
    }
}
