using Microsoft.AspNetCore.Mvc;

namespace DEX_MovieShopProject.Controllers
{
    public class OrderRowsController : Controller
    {
        public OrderRowsController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
