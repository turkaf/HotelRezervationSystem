using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly ICustomerService _customerService;

        public AdminDashboardController(IRoomService roomService, ICustomerService customerService)
        {
            _roomService = roomService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var totalRooms = _roomService.TGetList().Count();
            var totalCustomers = _customerService.TGetList().Count();
            
            ViewData["TotalRooms"] = totalRooms;
            ViewData["TotalCustomers"] = totalCustomers;
            return View();
        }
    }
}
