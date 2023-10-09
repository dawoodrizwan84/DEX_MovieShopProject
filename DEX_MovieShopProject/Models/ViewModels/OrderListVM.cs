namespace DEX_MovieShopProject.Models.ViewModels
{
    public class OrderListVM
    {
        public OrderListVM() 
        {
            CartMovies = new List<CartMovieVM>();
        }
        public List<CartMovieVM> CartMovies { get; set; }
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}
