using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
