
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DEX_MovieShopProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }


        public IActionResult Index() //List
        {
            var custList = _customerService.GetCustomer();

            return View(custList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer newCustomer)
        {
            _customerService.CreateCustomer(newCustomer);


            return RedirectToAction("Index");


        }

        public IActionResult Edit(int id)
        {
            var record = _customerService.GetCustomerById(id);
            return View(record);
        }

        [HttpPost]
        //[Route("ed")]
        public IActionResult Edit(Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return View(newCustomer);
            }

            var result = _customerService.UpdateCustomer(newCustomer);

            if (result)
            {
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Error has occured on server side.";
            return View(newCustomer);

        }


        public IActionResult Delete(int id)
        {
            var result = _customerService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var cust = _customerService.GetCustomerById(id);

            if (cust == null)
            {
                return NotFound();

            }
            return View(cust);

        }
    }
}
