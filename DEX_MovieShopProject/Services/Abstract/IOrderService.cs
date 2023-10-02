using DEX_MovieShopProject.Models;

namespace DEX_MovieShopProject.Services.Abstract
{
    public interface IOrderService
    {
        List<Order> orders { get; set; }

        void CreateOrder (Order order);
        void UpdateOrder (Order order);
        void DeleteOrder (Order order);
        void UpdateOrderStatus (Order order);
        void DeleteOrderStatusStatus (Order order);


    }
}
