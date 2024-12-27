using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelRezervationSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ICustomerService _customerService;

        public LoginController(IAdminService adminService, ICustomerService customerService)
        {
            _adminService = adminService;
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string FirstName, string LastName, string Email, string Phone, string Password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var newCustomer = new Customer
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                Password = Password
            };

            _customerService.TAdd(newCustomer);

            return RedirectToAction("SignIn");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string email, string password, string role)
        {
            if (role == "admin")
            {
                var admin = _adminService.ValidateAdmin(email, password);
                if (admin != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, admin.UserName),
                        new Claim(ClaimTypes.Role, "admin"),
                        new Claim("AminID", admin.AdminID.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "AdminDashboard");
                }
            }
            else if (role == "customer")
            {
                var customer = _customerService.ValidateCustomer(email, password);
                if (customer != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, customer.Email),
                        new Claim(ClaimTypes.Role, "customer"),
                        new Claim("CustomerID", customer.CustomerID.ToString()),
                        new Claim("FirstName", customer.FirstName),
                        new Claim("LastName", customer.LastName)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "CustomerRooms");
                }
            }

            ModelState.AddModelError("", "Invalid credentials or role.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();

            return RedirectToAction("SignIn", "Login");
        }
    }
}
