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



      
        public IActionResult Index() //List
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


           return RedirectToAction("Index");


       }

        public IActionResult Edit(int id)
        {
            var record = _movieService.GetMovieById(id);
            return View(record);
        }

        [HttpPost]
        //[Route("ed")]
        public IActionResult Edit(Movie newMovie)
        {
            if (!ModelState.IsValid)
            {
               return View(newMovie);
            }

            var result = _movieService.UpdateMovie(newMovie);

            if (result) 
            {
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Error has occured on server side.";
            return View(newMovie);

        }

        
        public IActionResult Delete(int id)
        {
            var result = _movieService.DeleteMovie(id);
            return RedirectToAction("Index");
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
