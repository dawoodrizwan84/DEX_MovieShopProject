using DEX_MovieShopProject.Controllers;
using DEX_MovieShopProject.Data;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Service.Abstract;

namespace DEX_MovieShopProject.Service.Implementation
{
    public class MovieService : IMovieService
    {
      

        private readonly AppDbContext _db;

        public MovieService(AppDbContext db)
            
        {
            _db = db;
           

        }
        public void CreateMovie(Movie newMovie) 
        {
            _db.Movies.Add(newMovie);
            _db.SaveChanges();

        }
    }
}
