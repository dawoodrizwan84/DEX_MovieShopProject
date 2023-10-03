using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Models.ViewModels;
using DEX_MovieShopProject.Service.Abstract;
using DEX_MovieShopProject.Services.Abstract;
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

        public HomeController(ILogger<HomeController> logger,
            IMovieService movieService,
            ICustomerService  customerService )
        {
            _logger = logger;
            _customerService = customerService;
            _movieService = movieService;
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

            frontPage.TopSellerMovies = movies;


            //FrontPageVM frontPage = new FrontPageVM();
            //frontPage.CheapMovies = _movieService.GetMovies();
            //frontPage.TopFiveMovies = _movieService.GetMovies();


            return View(movies);

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