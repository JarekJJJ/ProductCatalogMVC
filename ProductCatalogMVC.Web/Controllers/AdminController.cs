using Microsoft.AspNetCore.Mvc;

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
       
       
    }
}
