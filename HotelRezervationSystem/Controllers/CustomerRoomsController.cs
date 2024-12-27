using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    public class CustomerRoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public CustomerRoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            var values = _roomService.TGetListRoomWithType();
            return View(values);
        }
    }
}
