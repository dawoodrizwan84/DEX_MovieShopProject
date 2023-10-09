using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Models.ViewModels;

namespace DEX_MovieShopProject.Services.Abstract
{
    public interface IOrderService
    {
        
        //List<Movie> GetMostSoldMovies();
        CartVM GetCartVM(List<int> movieIdList);


    }
}
