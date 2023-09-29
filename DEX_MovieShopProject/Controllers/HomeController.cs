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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            //var movies = _movieService.GetMovies();

            //FrontPageVM frontPage = new FrontPageVM();

            //frontPage.TopFiveMovies = _movieService.GetMovies();

            //frontPage.CheapMovies = movies
            //    .OrderBy(m => m.Price)
            //    .Take(5).ToList();

            //frontPage.NewestMovies = movies
            //   .OrderByDescending(m => m.ReleaseYear)
            //   .Take(5).ToList();

            //frontPage.OldestMovies = movies
            //  .OrderBy(m => m.ReleaseYear)
            //  .Take(5).ToList();

            //frontPage.TopSellerMovies = movies;

            return View(/*frontPage*/);

            //FrontPageVM frontPage = new FrontPageVM();
            //frontPage.CheapMovies = _movieService.GetMovies();
            //frontPage.TopFiveMovies = _movieService.GetMovies();

            return View();

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