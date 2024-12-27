using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelRezervationSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminCustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public AdminCustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var values = _customerService.TGetList();
            return View(values);
        }

        [HttpPost]
        public IActionResult DeleteCustomer(int CustomerID)
        {
            var customer = _customerService.TGetByID(CustomerID);

            if (customer != null)
            {
                _customerService.TDelete(customer);
            }

            return RedirectToAction("Index");
        }
    }
}
