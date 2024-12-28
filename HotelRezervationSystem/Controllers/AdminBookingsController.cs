using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminBookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public AdminBookingsController(IBookingService bookingService, IRoomService roomService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            var values = _bookingService.TGetListBookingWithCustomerAndRoom();

            var today = DateTime.Now.Date;

            foreach (var booking in values)
            {
                if (booking.Status == true && booking.CheckOutDate.Date < today)
                {
                    var room = _roomService.TGetByID(booking.RoomID);
                    if (room != null)
                    {
                        room.Status = true;
                        _roomService.TUpdate(room);
                    }

                    booking.Status = false;
                    _bookingService.TUpdate(booking);
                }
                else if (booking.Status == false)
                {
                    var room = _roomService.TGetByID(booking.RoomID);
                    if (room != null)
                    {
                        room.Status = true;
                        _roomService.TUpdate(room);
                    }
                }
                else if(booking.Status == true)
                {
                    var room = _roomService.TGetByID(booking.RoomID);
                    if (room != null)
                    {
                        room.Status = false;
                        _roomService.TUpdate(room);
                    }
                }
            }

            return View(values);
        }

        [HttpPost]
        public IActionResult CancelBooking(int bookingId)
        {
            var booking = _bookingService.TGetByID(bookingId);
            if (booking == null)
            {
                TempData["ErrorMessage"] = "Booking not found.";
                return RedirectToAction("Index");
            }

            booking.Status = false;
            _bookingService.TUpdate(booking);

            var room = _roomService.TGetByID(booking.RoomID);

            room.Status = true;
            _roomService.TUpdate(room);

            TempData["SuccessMessage"] = "Booking canceled successfully!";
            return RedirectToAction("Index");
        }
    }
}
