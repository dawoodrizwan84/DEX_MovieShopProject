using DEX_MovieShopProject.Models;
namespace DEX_MovieShopProject.Services.Abstract
{
    public interface IOrderService
    {
        List<Order> GetOrders();

        void CreateOrder(Order newOrder);
        bool UpdateOrder(Order newOrder);
        
        Order GetOrderById(int id);
        bool DeleteOrder(int id);
    }
}
