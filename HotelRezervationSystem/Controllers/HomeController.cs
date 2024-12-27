using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoomService _roomService;

        public HomeController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            var allRooms = _roomService.TGetListRoomWithType();

            var highestRatedRoom = allRooms
                .OrderByDescending(r => r.Rating)
                .FirstOrDefault();

            var secondHighestRatedRoom = allRooms
                .OrderByDescending(r => r.Rating)
                .Skip(1)
                .FirstOrDefault();

            var lowestPriceRoom = allRooms
                .OrderBy(r => r.PricePerNight)
                .FirstOrDefault();

            var selectedRooms = new List<Room>
            {
                highestRatedRoom,
                secondHighestRatedRoom,
                lowestPriceRoom
            };

            return View(selectedRooms);
        }
    }
}
