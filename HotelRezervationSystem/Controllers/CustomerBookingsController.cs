using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    public class CustomerBookingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
