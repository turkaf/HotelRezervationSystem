﻿using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
