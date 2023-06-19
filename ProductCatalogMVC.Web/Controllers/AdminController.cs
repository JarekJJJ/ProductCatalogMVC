using Microsoft.AspNetCore.Mvc;
using ProductCatalogMVC.Application.Services;
using ProductCatalogMVC.Application.Interfaces;
using ProductCatalogMVC.Domain.Interface;
using System.Xml.Linq;
using ProductCatalogMVC.Application.ViewModels.Admin;
using ProductCatalogMVC.Application.ViewModels.Category;
//using System.Xml.Serialization;

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
        public IActionResult AddConnectionCategory(int? warehouseId, int? suppCategoryId, int? newCatalogCategory)
        {
            NewConnectionCategoryVm vm = new NewConnectionCategoryVm();
            var listConnection = _adminService.AddConnectionCategory(vm, warehouseId, suppCategoryId, newCatalogCategory);
            return View(listConnection);
        }
        [HttpPost]
        public IActionResult AddConnectionCategory(NewConnectionCategoryVm model, int warehouseId, int suppCategoryId, int newCatalogCategory)
        {
            //if(warehouseId != null && suppCategoryId!=null && newCatalogCategory!=null)
            //{
            //}
            var listConnection = _adminService.AddConnectionCategory(model, warehouseId, suppCategoryId, newCatalogCategory);

            return View();
        }

        [HttpGet]
        public IActionResult AddCatalogCategory()
        {
            NewCatalogCategoryVm vm = new NewCatalogCategoryVm();
            var ListCatalogCategory = _adminService.AddCatalogCategory(vm);

            //NewCatalogCategoryVm vm = new NewCatalogCategoryVm();
            //vm.CatalogCategoryList.AddRange(ListCatalogCategory);


            return View(ListCatalogCategory);
        }
        [HttpPost]
        public IActionResult AddCatalogCategory(NewCatalogCategoryVm model)
        {
            var id = _adminService.AddCatalogCategory(model);

            return RedirectToAction("AddCatalogCategory");
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
        [HttpGet]
        public IActionResult AddSuppCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSuppCategory(IFormFile model)
        {
            if (model != null && model.Length > 0)
            {

                var listSupCategory = XDocument.Load(model.OpenReadStream());
                _adminService.LoadXmlCategory(listSupCategory);
                //var xmlDoc = new XmlDocument();
                //xmlDoc.Load(model.OpenReadStream());
                //AddSuppCategory(xmlDoc);


            }
            return View();
        }
        [HttpGet]
        public IActionResult AddItemsXML()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddItemsXML(IFormFile model)
        {
            if (model != null && model.Length > 0)
            {

                var listItemsXML = XDocument.Load(model.OpenReadStream());
                _adminService.LoadItemsXML(listItemsXML);
                // _adminService.LoadXmlCategory(listSupCategory);
                //var xmlDoc = new XmlDocument();
                //xmlDoc.Load(model.OpenReadStream());
                //AddSuppCategory(xmlDoc);


            }
            return View();
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
