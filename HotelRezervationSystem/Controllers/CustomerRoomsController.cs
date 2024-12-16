using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    public class CustomerRoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
