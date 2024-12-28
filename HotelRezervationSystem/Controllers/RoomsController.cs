using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IActionResult Index(string destination, string guests)
        {
            var values = _roomService.TGetListRoomWithType();

			if (!string.IsNullOrEmpty(destination))
			{
				values = values.Where(x => x.City.Contains(destination, StringComparison.OrdinalIgnoreCase)).ToList();
			}

			if (!string.IsNullOrEmpty(guests))
			{
				if (guests == "4+")
				{
					values = values.Where(x => x.Capacity >= 4).ToList();
				}
				else
				{
					int guestCount = int.Parse(guests);
					values = values.Where(x => x.Capacity >= guestCount).ToList();
				}
			}

			return View(values);
        }
    }
}
