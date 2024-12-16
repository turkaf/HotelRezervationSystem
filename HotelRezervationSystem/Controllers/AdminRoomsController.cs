using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    public class AdminRoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
