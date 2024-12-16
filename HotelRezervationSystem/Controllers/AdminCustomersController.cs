using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    public class AdminCustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
