namespace DEX_MovieShopProject.Models.ViewModels
{
    public class ConfirmVM
    {
        public Movie Movie { get; set; }
        public Customer Customer { get; set; }
        public CartVM Cart {  get; set; }
    }
}
