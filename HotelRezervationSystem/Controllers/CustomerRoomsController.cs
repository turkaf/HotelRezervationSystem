using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    [Authorize(Roles = "customer")]
    public class CustomerRoomsController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;

        public CustomerRoomsController(IRoomService roomService, IBookingService bookingService)
        {
            _roomService = roomService;
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            var values = _roomService.TGetListRoomWithType();

            foreach (var room in values)
            {
                var roomBookings = _bookingService.TGetListBookingWithCustomerAndRoom()
                    .Where(b => b.RoomID == room.RoomID && b.Rating.HasValue)
                    .ToList();

                if (roomBookings.Any())
                {
                    var averageRating = roomBookings.Average(b => b.Rating.Value);
                    room.Rating = averageRating;

                    _roomService.TUpdate(room);
                }
                else
                {
                    room.Rating = null;
                }
            }

            var city = Request.Query["city"].ToString();
			if (!string.IsNullOrEmpty(city))
			{
				values = values.Where(x => x.City.Contains(city, System.StringComparison.OrdinalIgnoreCase)).ToList();
			}

            var capacity = Request.Query["capacity"].ToString();
            if (!string.IsNullOrEmpty(capacity))
            {
                if (capacity == "4+")
                {
                    values = values.Where(x => x.Capacity >= 4).ToList();
                }
                else
                {
                    int guestCount = int.Parse(capacity);
                    values = values.Where(x => x.Capacity >= guestCount).ToList();
                }
            }

            return View(values);
        }

        public IActionResult MakeRezervation(int roomId)
        {
            var room = _roomService.TGetByID(roomId);
            if (room == null)
            {
                return RedirectToAction("Index", "CustomerRooms");
            }

            ViewBag.RoomId = room.RoomID;
            ViewBag.RoomName = room.Name;
            ViewBag.City = room.City;
            ViewBag.PricePerNight = room.PricePerNight;
            ViewBag.Capacity = room.Capacity;

            return View();
        }

    }
}
