using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminBookingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
