using DEX_MovieShopProject.Models;

namespace DEX_MovieShopProject.Service.Abstract
{
    public interface IMovieService
    {

        List<Movie> GetMovies();

        void CreateMovie(Movie newMovie);

        void UpdateMovie(Movie newMovie);

        void DeleteMovie(Movie newMovie);

        //void Data(int id, Movie newMovie);

        Movie GetMovieById(int id);



    }
}
