using DEX_MovieShopProject.Helpers;
using DEX_MovieShopProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEX_MovieShopProject.Controllers
{
    public class OrderRowsController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
