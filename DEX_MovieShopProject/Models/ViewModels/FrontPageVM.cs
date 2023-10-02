
namespace DEX_MovieShopProject.Models.ViewModels
{
    public class FrontPageVM
    {
        public List<Movie> TopFiveMovies { get; set; }

        public List<Movie> CheapMovies { get; set;}

        public List<Movie> TopSellerMovies { get; set;}

        public List<Movie> NewestMovies { get; set;}

        public List<Movie> OldestMovies { get; set; }

        Customer BestCustomer { get; set; }

        public Order TotalOrder { get; set; }
        
    }
}
