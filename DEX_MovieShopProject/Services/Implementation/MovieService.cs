using DEX_MovieShopProject.Controllers;
using DEX_MovieShopProject.Data;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Service.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging.Abstractions;

namespace DEX_MovieShopProject.Service.Implementation
{
    public class MovieService : IMovieService
    {


        private readonly AppDbContext _db;

        public MovieService(AppDbContext db)

        {
            _db = db;

        }

        public List<Movie> GetMovies()
        {
            return _db.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _db.Movies.Where(m => m.Id == id).FirstOrDefault();
        }
        public void CreateMovie(Movie newMovie)
        {
            _db.Movies.Add(newMovie);
            _db.SaveChanges();

        }

        public void UpdateMovie(Movie newMovie)
        {
            _db.Movies.Update(newMovie);
            _db.SaveChanges();
        }

        public void DeleteMovie(Movie newMovie)
        {
            _db.Remove(newMovie);
            _db.SaveChanges();
        }



        //public void Data(int id, Movie newMovie)
        //{

        //    var movieInDb = _db.Movies.FirstOrDefault(m => m.Id == newMovie.Id);

        //    if (movieInDb != null)
        //    {

        //        movieInDb.Title = newMovie.Title;

        //        _db.SaveChanges();
        //    }
        //}

    }
}
