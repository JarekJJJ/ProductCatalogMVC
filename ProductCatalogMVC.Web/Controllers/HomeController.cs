using Microsoft.AspNetCore.Mvc;
using ProductCatalogMVC.Web.Models;
using System.Diagnostics;

namespace ProductCatalogMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewListOfItem() 
        {
        List<Item> items = new List<Item>();
            items.Add(new Item() { Id = 1, Name = "Mysz Logitech M185"
                , ShortDescription = "Mysz bezprzewodowa", Category = "Peryferia"
                , Prize = 12.34M, Quantity = 7 });
            items.Add(new Item()
            {
                Id = 2,
                Name = "Procesor Intel I5-11400F",                
                ShortDescription = "Procesor 11-gen",
                Category = "Procesory",
                Prize = 612.34M,
                Quantity = 2
            });
            items.Add(new Item()
            {
                Id = 3,
                Name = "Monitor Philips 223y76a",
                ShortDescription = "Monitor 23\"",
                Category = "Monitory",
                Prize = 518.34M,
                Quantity = 32
            });
            return View(items);

        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}