using Microsoft.AspNetCore.Mvc;

namespace LibararyApp.Controllers
{
    public class DatabaseController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


    }
}
