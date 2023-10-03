using DEX_MovieShopProject.Models;

namespace DEX_MovieShopProject.Services.Abstract
{
    public interface IOrderService
    {
        List<Order> GetOrders();

        void CreateOrder (Order order);
        void UpdateOrder (Order order);
        void DeleteOrder (Order order);
        void UpdateOrderStatus (Order order);
       


    }
}
