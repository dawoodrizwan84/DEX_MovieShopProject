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

        public OrderService(AppDbContext db,IMovieService movieService)

        {
            _db = db;
            _movieService = movieService;

        }

        
        //public List<Movie> GetMostSoldMovies()
        //{
        //    var groupMovies = _db.OrderRows.GroupBy(x => x.MovieId)
        //        .Select(x => new
        //        {
        //            movieId = x.Key,
        //            soldCopies=x.Count()
        //        })
        //        .OrderByDescending(x=>x.soldCopies).Take(5).ToList();
        //    var popMovies=new List<Movie>();
        //    foreach (var item in groupMovies)
        //    {

        //        popMovies.Add(_movieService.GetMovies(item.movieId));
        //    }
        //    return popMovies;
        //}

        public CartVM GetCartVM(List<int>movieIdList)
        {
            var uniqueMovies = _db.Movies
                .Where(m => movieIdList
                .Any(i => i == m.Id));

            var cartMovies = movieIdList.GroupBy(x => x)
                .Select(g => new CartMovieVM() 
                { 
                    Movie = uniqueMovies
                    .Where(m=>m.Id==g.Key)
                    .FirstOrDefault(),
                    NoOfCopies=g.Count(),
                    SubTotal=g.Count()*uniqueMovies
                    .Where(m => m.Id == g.Key)
                    .FirstOrDefault().Price

                }).ToList();

<<<<<<< Updated upstream
            CartVM cartVM = new CartVM();
            cartVM.CartMovies = cartMovies;
            cartVM.Total = cartMovies.Sum(cm => cm.SubTotal);
=======
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

        public List<Order> Order()
        {
            throw new NotImplementedException();
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

>>>>>>> Stashed changes
            return cartVM;

        }
    }
}
