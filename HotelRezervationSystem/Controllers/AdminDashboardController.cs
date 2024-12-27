using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminDashboardController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;

        public AdminDashboardController(IRoomService roomService, ICustomerService customerService, IBookingService bookingService)
        {
            _roomService = roomService;
            _customerService = customerService;
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            var totalRooms = _roomService.TGetList().Count();
            var totalCustomers = _customerService.TGetList().Count();
            var totalBookings = _bookingService.TGetList().Count();
            
            ViewData["TotalRooms"] = totalRooms;
            ViewData["TotalCustomers"] = totalCustomers;
            ViewData["TotalBookings"] = totalBookings;
            return View();
        }
    }
}
