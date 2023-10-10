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

        public OrderController(IOrderService orderService)
        {
            
            _orderService = orderService;
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


        public IActionResult ShoppingCart()
        {

            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList");

            var queyrResult = _orderService.GetCartVM(movieIdsList);



            return View(queyrResult);
        }


    }
}
