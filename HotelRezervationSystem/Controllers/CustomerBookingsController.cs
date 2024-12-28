using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using HotelRezervationSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    [Authorize(Roles = "customer")]
    public class CustomerBookingsController : Controller
    {
        IBookingService _bookingService;
        IRoomService _roomService;

        public CustomerBookingsController(IBookingService bookingService, IRoomService roomService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            var customerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "CustomerID")?.Value);

            var bookings = _bookingService.TGetListBookingWithCustomerAndRoom()
                .Where(a => a.CustomerID == customerId)
                .Select(a => new BookingListViewModel
                {
                    ID = a.BookingID,
                    RoomName = a.Room.Name,
                    City = a.Room.City,
                    CheckInDate = a.CheckInDate.ToString("dd.MM.yyyy"),
                    CheckOutDate = a.CheckOutDate.ToString("dd.MM.yyyy"),
                    TotalPrice = a.TotalPrice,
                    Status = a.Status
                })
                .ToList();

            return View(bookings);
        }

        [HttpGet]
        public IActionResult BookingDetail(int bookingId)
        {
            var booking = _bookingService.TGetListBookingWithCustomerAndRoom()
                .FirstOrDefault(a => a.BookingID == bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            var bookingDetails = new BookingDetailViewModel
            {
                RoomName = booking.Room.Name,
                City = booking.Room.City,
                CheckInDate = booking.CheckInDate.ToString("dd.MM.yyyy"),
                CheckOutDate = booking.CheckOutDate.ToString("dd.MM.yyyy"),
                TotalPrice = booking.TotalPrice,
                Photo = booking.Room.Photo,
                Status = booking.Status
            };

            return View(bookingDetails);
        }

        [HttpPost]
        public IActionResult CancelBooking(int bookingId)
        {
            var booking = _bookingService.TGetByID(bookingId);
            if (booking != null)
            {
                booking.Status = false;
                _bookingService.TUpdate(booking);

                var room = _roomService.TGetByID(booking.RoomID);

                room.Status = true;
                _roomService.TUpdate(room);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateBooking(int roomId, double pricePerNight, DateTime checkIn, DateTime checkOut)
        {
            var customerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "CustomerID")?.Value);

            var room = _roomService.TGetByID(roomId);
            if (room == null)
            {
                return RedirectToAction("Index", "CustomerRooms");
            }

            var days = (checkOut - checkIn).Days + 1;

            var totalPrice = pricePerNight * days;

            var booking = new Booking
            {
                CustomerID = customerId,
                RoomID = roomId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                BookingDate = DateTime.Now,
                TotalPrice = totalPrice,
                Status = true
            };

            _bookingService.TAdd(booking);

            room.Status = false;
            _roomService.TUpdate(room);

            return RedirectToAction("Index", "CustomerBookings");
        }

        [HttpPost]
        public IActionResult SubmitRating([FromBody] SubmitRatingRequest model)
        {
            var booking = _bookingService.TGetByID(model.BookingId);
            if (booking == null)
            {
                return Json(new { success = false, message = "Booking not found." });
            }

            booking.Rating = model.Rating;

            _bookingService.TUpdate(booking);

            return Json(new { success = true });
        }

        public class SubmitRatingRequest
        {
            public int BookingId { get; set; }
            public int Rating { get; set; }
        }
    }
}
