using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Models.ViewModels;

namespace DEX_MovieShopProject.Services.Abstract
{
    public interface IOrderService
    {
        List<Order> GetOrders();

        void CreateOrder(Order newOrder);
        bool UpdateOrder(Order newOrder);

        Order GetOrderById(int id);
        bool DeleteOrder(int id);

        CartVM GetCartVM(List<int> movieIdsList);






    }
}
