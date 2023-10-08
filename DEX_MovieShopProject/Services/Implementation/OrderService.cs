using DEX_MovieShopProject.Data;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Models.ViewModels;
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

        public CartVM GetCartVM(List<int> movieIdList)
        {
            var uniqueMovies = _db.Movies
                    .Where(m => movieIdList
                    .Any(i => i == m.Id));

            var cartMovies = movieIdList.GroupBy(x => x)
                    .Select(g => new CartMovieVM()
                    {
                        Movie = uniqueMovies
                    .Where(m => m.Id == g.Key)
                    .FirstOrDefault(),
                        SubTotal = g.Count() * uniqueMovies
                    .Where(m => m.Id == g.Key)
                    .FirstOrDefault().Price

                    }).ToList();

            CartVM cartVM = new CartVM();
            cartVM.CartMovies = cartMovies;
            cartVM.Total = cartMovies.Sum(cm => cm.SubTotal);

            return cartVM;

        }




    }
}

