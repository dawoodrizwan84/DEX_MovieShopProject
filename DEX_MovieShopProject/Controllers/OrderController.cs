using DEX_MovieShopProject.Helpers;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DEX_MovieShopProject.Controllers
{
    public class OrderController : Controller
    {

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
            var cart = new CartVM();

            CartMovieVM newCartMovie = new CartMovieVM();
            newCartMovie.Movie = new Movie() { Title = "First title" };
            newCartMovie.NoOfCopies = 2;
            newCartMovie.SubTotal = 200;
            cart.CartMovies.Add(newCartMovie);

            CartMovieVM newCartMovie2 = new CartMovieVM();
            newCartMovie2.Movie = new Movie() { Title = "Second title" };
            newCartMovie2.NoOfCopies = 2;
            newCartMovie2.SubTotal = 400;
            cart.CartMovies.Add(newCartMovie2);

            cart.Total = 600;

            return View(cart);
        }
    }
}
