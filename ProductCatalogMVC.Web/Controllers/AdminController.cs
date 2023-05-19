using Microsoft.AspNetCore.Mvc;
using ProductCatalogMVC.Application.Services;

namespace ProductCatalogMVC.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            //import produktów
            //dodawanie produktu

            return View();
        }
        [HttpGet]
        public IActionResult AddItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddItem(ItemModel model) 
        { 
            var id = ItemService.AddItem(model);
            return View();
        }

       
       
    }
}
