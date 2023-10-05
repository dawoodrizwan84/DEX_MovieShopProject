using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Models.ViewModels;
using DEX_MovieShopProject.Service.Abstract;
using DEX_MovieShopProject.Services.Abstract;
using DEX_MovieShopProject.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DEX_MovieShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMovieService _movieService;
        private readonly ICustomerService _customerService;
        //private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger,
            IMovieService movieService,
            ICustomerService  customerService
            /*IOrderService orderService*/)
        {
            _logger = logger;
            _customerService = customerService;
            _movieService = movieService;
            //_orderService = orderService;
        }

      
        public IActionResult Index()
        {


            var movies = _movieService.GetMovies();

            FrontPageVM frontPage = new FrontPageVM();

            frontPage.TopFiveMovies = _movieService.GetMovies();

            frontPage.CheapMovies = movies
                .OrderBy(m => m.Price)
                .Take(5).ToList();

            frontPage.NewestMovies = movies
               .OrderByDescending(m => m.ReleaseYear)
               .Take(5).ToList();

            frontPage.OldestMovies = movies
              .OrderBy(m => m.ReleaseYear)
              .Take(5).ToList();

            frontPage.AllMovies = movies
                .OrderByDescending(m => m.Title)
                //.Take(Range.All)
                .Take(6)
                .ToList();

            frontPage.TopSellerMovies = movies;

            return View(frontPage);


        }

        //public IActionResult Search(String query)
        //{
        //    var movies = _movieService.GetMovies();

        //    FrontPageVM frontPage = new FrontPageVM();

        //    frontPage.SearchMovie = movies
        //        .Where(m =>
        //    m.Title.Contains() || // Case-insensitive search by title
        //    m.Director.Contains() || // Case-insensitive search by director
        //    m.Price.ToString().Contains() // Case-insensitive search by price (converted to string)
        //)
        //.ToList();

        //    return View("SearchResults");
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}