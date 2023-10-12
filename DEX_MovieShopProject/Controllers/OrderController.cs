using DEX_MovieShopProject.Helpers;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Models.ViewModels;
using DEX_MovieShopProject.Service.Abstract;
using DEX_MovieShopProject.Services.Abstract;
using DEX_MovieShopProject.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace DEX_MovieShopProject.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;


        public OrderController(IOrderService orderService, ICustomerService customerService)
        {

            _orderService = orderService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddtoCart(string id)
        {
            if (HttpContext.Session.Get<List<int>>("movieIdList") == default)
            {
                HttpContext.Session.Set<List<int>>("movieIdList", new List<int>());

            }
            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList");
            movieIdsList.Add(Convert.ToInt32(id));

            HttpContext.Session.Set<List<int>>("movieIdList", movieIdsList);

            return Json(movieIdsList.Count);
        }

        public IActionResult ShoppingCart()
        {

            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList");

            var queyrResult = _orderService.GetCartVM(movieIdsList);



            return View(queyrResult);
        }

        public IActionResult ConfirmOrder(string emailAddress)
        {
            ConfirmVM confirmVM = new ConfirmVM();
            confirmVM.customer = _customerService.GetCustomer(emailAddress);

            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList");
            confirmVM.cart = _orderService.GetCartVM(movieIdsList);

            TempData["email"] = emailAddress;

            return View(confirmVM);
        }


        public IActionResult CreateOrder()
        {
            var email = (string)TempData["email"];
            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList");
            var cart = _orderService.GetCartVM(movieIdsList);

            _orderService.AddOrder(email, cart.CartMovies);

            return RedirectToAction("ThankYou", "Customer");

        }

    

      


    }
}
