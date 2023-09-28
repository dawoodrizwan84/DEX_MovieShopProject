using DEX_MovieShopProject.Data;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Models.ViewModels;
using DEX_MovieShopProject.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DEX_MovieShopProject.Controllers
{
    public class MovieController : Controller
    {

        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }



        [Route("MI")]
        public IActionResult Index()
        {
            var movieList = _movieService.GetMovies();

            return View();
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie newMovie) 
        {
            _movieService.CreateMovie(newMovie);

            return RedirectToAction("Index", "Movie");
        }

        public IActionResult Edit()
        {
            var movieList = _movieService.GetMovies();

            return View(movieList);
        }

        [HttpPost]
        //[Route("ed")]
        public IActionResult Edit(Movie newMovie)
        {
            _movieService.UppMovie(newMovie);

            return View(newMovie);

        }

    }
}
