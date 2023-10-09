using DEX_MovieShopProject.Data;
using DEX_MovieShopProject.Helpers;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Models.ViewModels;
using DEX_MovieShopProject.Service.Abstract;
using DEX_MovieShopProject.Services.Abstract;
using DEX_MovieShopProject.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DEX_MovieShopProject.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private IMovieService _movieService;
        private readonly AppDbContext _db;

        public OrderController(IOrderService orderService,ICustomerService customerService,IMovieService movieService, AppDbContext db)
        {
            
            _orderService = orderService;
            _customerService = customerService;
            _movieService = movieService;
            _db = db;
        }

        [Route("OL")]
        public IActionResult Index()
        {
            string userId = "";
            var orderList = _orderService.GetOrders();

            return View(orderList);
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

        //public IActionResult AddItemToShoppingCAART(int Id)
        //{
        //    var item=_movieService.GetMovieById(Id);
        //    if (item != null)
        //    {
        //    _
        //    }
            
        //    return
        //}

        public IActionResult ConfirmOrder(string email)
        {
            ConfirmVM confirmVM = new ConfirmVM();
            confirmVM.Customer= _customerService.GetCustomer(email);

            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList");

            confirmVM.Cart = _orderService.GetCartVM(movieIdsList);

            TempData["email"] = email;

            return View(confirmVM);
        }


        public IActionResult CreateOrder()
        {
            var email = (string)TempData["email"];

            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList");

            var cart = _orderService.GetCartVM(movieIdsList);

            _orderService.AddOrder(email, cart.CartMovies);

            return RedirectToAction("ThankYou","Customer");
        }


    }
}
