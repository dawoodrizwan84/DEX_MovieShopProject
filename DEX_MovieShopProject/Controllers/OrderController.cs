using DEX_MovieShopProject.Helpers;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Service.Abstract;
using DEX_MovieShopProject.Services.Abstract;
using DEX_MovieShopProject.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace DEX_MovieShopProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }
        

        [Route("OI")]
        public IActionResult Index()
        {
            var orderList = _orderService.GetOrders();
            return View(orderList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Order newOrder)
        {
            _orderService.CreateOrder(newOrder);

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var record = _orderService.GetOrderById(id);

            return View(record);


        }

        [HttpPost]
        //[Route("od")]
        public IActionResult Edit(Order newOrder)
        {
            if (!ModelState.IsValid)
            {
                return View(newOrder);
            }
            var result = _orderService.UpdateOrder(newOrder);

            if (result)
            {
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Error has occured on server side.";
            return View(newOrder);
        }


        public IActionResult Delete(int id)
        {
            var result = _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var mo = _orderService.GetOrderById(id);

            if (mo == null)
            {
                return NotFound();

            }
            return View(mo);

        }


        [HttpPost]
        public IActionResult AddToCart(string id)
        {
            if(HttpContext.Session.Get<List<int>>("movieIdList")==default)
            {
                HttpContext.Session.Set<List<int>>("movieIdList", new List<int>());

            }
            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList");
            movieIdsList.Add(Convert.ToInt32(id));

            HttpContext.Session.Set<List<int>>("movieIdList", movieIdsList);

            return Json(movieIdsList.Count);
        }


    }
}
