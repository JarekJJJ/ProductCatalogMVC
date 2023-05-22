using Microsoft.AspNetCore.Mvc;
using ProductCatalogMVC.Application.Services;
using ProductCatalogMVC.Application.ViewModels.Item;
using ProductCatalogMVC.Application.Interfaces;
using ProductCatalogMVC.Domain.Interface;

namespace ProductCatalogMVC.Web.Controllers
{
    public class AdminController : Controller
    {
        private IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            //import kategorii
            //import produktów
            //dodawanie produktu

            return View();
        }
        [HttpGet]
        public IActionResult AddWarehouse()
        {
            return View(new NewWarehouseVm());
        }
        [HttpPost]
        public IActionResult AddWarehouse(NewWarehouseVm model) 
        {
            var id = _adminService.AddWarehouse(model);
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public IActionResult AddItem()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddItem(ItemModel model) 
        //{ 
        //    var id = ItemService.AddItem(model);
        //    return View();
        //}

       
       
    }
}
