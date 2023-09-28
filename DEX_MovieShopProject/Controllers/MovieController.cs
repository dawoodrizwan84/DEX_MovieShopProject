using DEX_MovieShopProject.Data;
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
            //var movData = movieDb.Movies.ToList();

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

            return RedirectToAction("Index", "Movie");
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


            return RedirectToAction("Index");

        }

        public IActionResult Delete(Movie newMovie)
        {
            
            _movieService.DeleteMovie(newMovie);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var mo = _movieService.GetMovieById(id);
            if (mo == null)
            {
               

            }
        return View();  

        }
    }
}
