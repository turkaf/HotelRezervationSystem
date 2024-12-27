using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    [Authorize(Roles = "customer")]
    public class CustomerBookingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
