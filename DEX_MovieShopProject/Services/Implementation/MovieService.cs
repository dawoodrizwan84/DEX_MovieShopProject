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
            return _db.Movies.Find(id);
        }
        public void CreateMovie(Movie newMovie)
        {
            _db.Movies.Add(newMovie);
            _db.SaveChanges();

        }

     
        public bool UpdateMovie(Movie newMovie)
        {
            try
            {
                _db.Movies.Update(newMovie);
                _db.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMovie(int id)
        {
            try
            {
                var data=this.GetMovieById(id);
                if(data == null)
                {
                    return false;
                }
                _db.Movies.Remove(data);
                _db.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
