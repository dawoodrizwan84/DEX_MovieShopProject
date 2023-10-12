using DEX_MovieShopProject.Data;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Models.ViewModels;
using DEX_MovieShopProject.Service.Abstract;
using DEX_MovieShopProject.Service.Implementation;
using DEX_MovieShopProject.Services.Abstract;

namespace DEX_MovieShopProject.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;
        private readonly IMovieService _movieService;

        public OrderService(AppDbContext db, IMovieService movieService)

        {
            _db = db;
            _movieService = movieService;

        }


        public List<Movie> GetMostSoldMovies()
        {
            var groupMovies = _db.OrderRows.GroupBy(x => x.MovieId)
                .Select(x => new
                {
                    movieId = x.Key,
                    soldCopies = x.Count()
                })
                .OrderByDescending(x => x.soldCopies).Take(5).ToList();
            var popMovies = new List<Movie>();
            foreach (var item in groupMovies)
            {
                popMovies.Add(_movieService.GetMovieById(item.movieId));
            }
            return popMovies;
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
                    NoOfCopies = g.Count(),
                    SubTotal = g.Count() * uniqueMovies
                    .Where(m => m.Id == g.Key)
                    .FirstOrDefault().Price

                }).ToList();

            CartVM cartVM = new CartVM();
            cartVM.CartMovies = cartMovies;
            cartVM.Total = cartMovies.Sum(cm => cm.SubTotal);
            return cartVM;
        }

        public void AddOrder(string email, List<CartMovieVM> cartMovies)
        {
            Order newOrder = new Order();
            newOrder.OrderDate = DateTime.Now;
            newOrder.Customer = _db.Customers
                                .Where(c => c.EmailAddress == email)
                                .FirstOrDefault();
            List<OrderRow> orderRows = new List<OrderRow>();
            foreach (var item in cartMovies)
            {
                for (int i = 0; i < item.NoOfCopies; i++)

                {
                    OrderRow row = new OrderRow()
                    {
                        MovieId = item.Movie.Id,
                        Price = item.Movie.Price
                    };
                    orderRows.Add(row);
                }
            }

            newOrder.OrderRows = orderRows;
            _db.Orders.Add(newOrder);
            _db.SaveChanges();

        }
    }
}