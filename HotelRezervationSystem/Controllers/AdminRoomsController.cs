﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HotelRezervationSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminRoomsController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;

        public AdminRoomsController(IRoomService roomService, IRoomTypeService roomTypeService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
        }

        public IActionResult Index()
        {
            var values = _roomService.TGetListRoomWithType();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRoom()
        {
            var roomTypes = _roomTypeService.TGetList();
            ViewBag.RoomTypes = roomTypes;
            return View();
        }

        [HttpPost]
        public IActionResult AddRoom(Room room, IFormFile Photo)
        {
            var roomTypes = _roomTypeService.TGetList();
            ViewBag.RoomTypes = roomTypes;

            if (int.TryParse(Request.Form["RoomTypeID"], out int roomTypeId))
            {
                room.RoomTypeID = roomTypeId;
            }
            else
            {
                ModelState.AddModelError("RoomTypeID", "Invalid Clinic selected.");
                return View(room);
            }

            if (Photo == null || Photo.Length == 0)
            {
                ModelState.AddModelError("Photo", "Photo is required.");
                return View(room);
            }

            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "roomimages");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(Photo.FileName);
            var filePath = Path.Combine(directoryPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(stream);
            }

            room.Photo = "/roomimages/" + uniqueFileName;

            _roomService.TAdd(room);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteRoom(int RoomID)
        {
            var room = _roomService.TGetByID(RoomID);

            if (room != null)
            {
                var photoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", room.Photo.TrimStart('/'));
                if (System.IO.File.Exists(photoPath))
                {
                    System.IO.File.Delete(photoPath);
                }

                _roomService.TDelete(room);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditRoom(int id)
        {
            var room = _roomService.TGetByID(id);
            if (room == null)
            {
                return NotFound();
            }

            var roomTypes = _roomTypeService.TGetList();
            ViewBag.RoomTypes = roomTypes;

            return View(room);
        }

        [HttpPost]
        public IActionResult EditRoom(int id, Room room, IFormFile Photo)
        {
            Console.WriteLine($"Received ID: {id}");

            if (!ModelState.IsValid)
            {
                var roomTypes = _roomTypeService.TGetList();
                ViewBag.RoomTypes = roomTypes;

                foreach (var error in ModelState)
                {
                    foreach (var item in error.Value.Errors)
                    {
                        Console.WriteLine($"Error in {error.Key}: {item.ErrorMessage}");
                    }
                }

                return View(room);
            }

            var existingRoom = _roomService.TGetByID(id);
            if (existingRoom == null)
            {
                return NotFound();
            }

            if (Photo != null && Photo.Length > 0)
            {
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "roomimages");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(Photo.FileName);
                var filePath = Path.Combine(directoryPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(stream);
                }

                room.Photo = "/roomimages/" + uniqueFileName;
            }
            else
            {
                room.Photo = existingRoom.Photo;
            }

            _roomService.TUpdate(room);

            return RedirectToAction("Index");
        }
    }
}
