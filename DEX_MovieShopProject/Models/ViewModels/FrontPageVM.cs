
namespace DEX_MovieShopProject.Models.ViewModels
{
    public class FrontPageVM
    {
        public List<Movie> TopFiveMovies { get; set; }

        public List<Movie> CheapMovies { get; set;}

        Customer BestCustomer { get; set; }
    }
}
