using DEX_MovieShopProject.Models;
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

            return View(movieList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie newMovie)
        {
            _movieService.CreateMovie(newMovie);

            return View();

        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        //[Route("ed")]
        public IActionResult Edit(Movie newMovie)
        {

            _movieService.UpdateMovie(newMovie);

            return View(newMovie);

            //return RedirectToAction("Index");
        }


        public IActionResult Delete(Movie newMovie)
        {

            _movieService.DeleteMovie(newMovie);

            return View(newMovie);
        }

        public IActionResult Details(int id)
        {
            var mo = _movieService.GetMovieById(id);

            if (mo == null)
            {
                return NotFound();

            }
            return View(mo);

        }
    }
}
