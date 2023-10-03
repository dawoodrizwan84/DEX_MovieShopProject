using DEX_MovieShopProject.Models;

namespace DEX_MovieShopProject.Service.Abstract
{
    public interface IMovieService
    {

        List<Movie> GetMovies();

        void CreateMovie(Movie newMovie);

        bool UpdateMovie(Movie newMovie);

        Movie GetMovieById(int id);

        bool DeleteMovie(int id);


    }
}
