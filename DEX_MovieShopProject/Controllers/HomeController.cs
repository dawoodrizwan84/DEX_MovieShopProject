using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Models.ViewModels;
using DEX_MovieShopProject.Service.Abstract;
using DEX_MovieShopProject.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DEX_MovieShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService,ICustomerService customerService, IOrderService orderService)
        {
            _logger = logger;
            _movieService=movieService;
            _customerService=customerService;
            _orderService=orderService;
        }

        public IActionResult Index()
        {

            var movies = _movieService.GetMovies();

            FrontPageVM frontPage = new FrontPageVM();

            frontPage.TopFiveMovies = _orderService.GetMostSoldMovies();

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
                .Take(Range.All)
                //.Take(6)
                .ToList();


            frontPage.TopSellerMovies = movies;

            return View(frontPage);


        }

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