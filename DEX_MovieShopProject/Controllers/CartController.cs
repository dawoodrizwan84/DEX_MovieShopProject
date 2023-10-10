﻿using DEX_MovieShopProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Helpers;
using DEX_MovieShopProject.Services.Abstract;

namespace DEX_MovieShopProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public CartController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
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


        public IActionResult Index()
        {
            return View();
        }

<<<<<<< Updated upstream
        public IActionResult ShoppingCart()
=======
        public IActionResult ShoppingCart(List<int> movieIdList)
>>>>>>> Stashed changes
        {

<<<<<<< Updated upstream
            CartMovieVM newCartMovie = new CartMovieVM();

            //var queyrResult = _orderService.GetCartVM(movieIdsList);

            newCartMovie.Movie = new Movie() { Title = "First title" };
            newCartMovie.NoOfCopies = 2;
            newCartMovie.SubTotal = 200;

            CartMovieVM newCartMovie2 = new CartMovieVM();
            newCartMovie2.Movie = new Movie() { Title = "Second title" };
            newCartMovie2.NoOfCopies = 3;
            newCartMovie2.SubTotal = 600;
=======
            var uniqueMovies = _db.Movies
                     .Where(m => movieIdList
                     .Any(i => i == m.Id));
>>>>>>> Stashed changes

            var cartMovies = movieIdList.GroupBy(x => x)
                    .Select(g => new CartMovieVM()
                    {
                        Movie = uniqueMovies
                    .Where(m => m.Id == g.Key)
                    .FirstOrDefault(),
                        SubTotal = g.Count() * uniqueMovies
                    .Where(m => m.Id == g.Key)
                    .FirstOrDefault().Price

                    }).ToList();

            CartVM cartVM = new CartVM();
            cartVM.CartMovies = cartMovies;
            cartVM.Total = cartMovies.Sum(cm => cm.SubTotal);


            //var cart = new CartVM();
            //var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList");

            //CartMovieVM newCartMovie = new CartMovieVM();
            //newCartMovie.Movie = new Movie() { Title = "First title" };
            //newCartMovie.NoOfCopies = 2;
            //newCartMovie.SubTotal = 200;

            //CartMovieVM newCartMovie2 = new CartMovieVM();
            //newCartMovie2.Movie = new Movie() { Title = "Second title" };
            //newCartMovie2.NoOfCopies = 3;
            //newCartMovie2.SubTotal = 600;

            //cart.CartMovies.Add(newCartMovie);
            //cart.CartMovies.Add(newCartMovie2);

            //cart.Total = 800;

            return View(cartVM);
        }
    }
}
