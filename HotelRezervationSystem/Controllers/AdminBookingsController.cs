using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    public class AdminBookingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
