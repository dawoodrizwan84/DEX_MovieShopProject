namespace DEX_MovieShopProject.Models.ViewModels
{
    public class CartVM
    {
        public CartVM() 
        {
            CartMovies=new List<CartMovieVM>();
        }
        public List<CartMovieVM> CartMovies { get; set; }
        public decimal Total { get; set; }
    }
}
