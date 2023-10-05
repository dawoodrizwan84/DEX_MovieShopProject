using DEX_MovieShopProject.Data;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Services.Abstract;

namespace DEX_MovieShopProject.Services.Implementation
{
    public class OrderService : IOrderService
    {

        private readonly AppDbContext _db;

        public OrderService(AppDbContext db)

        {
            _db = db;

        }
        List<Order> Orders { get; set; } = new List<Order>();
        public List<Order> GetOrders()
        {
            return _db.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _db.Orders.Find(id);
        }

        public void CreateOrder(Order newOrder)
        {
            _db.Orders.Add(newOrder);
            _db.SaveChanges();

        }


        public bool UpdateOrder(Order newOrder)
        {
            try
            {
                _db.Orders.Update(newOrder);
                _db.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteOrder(int id)
        {
            try
            {
                var data = this.GetOrderById(id);
                if (data == null)
                {
                    return false;
                }
                _db.Orders.Remove(data);
                _db.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

     

       
    }
}

