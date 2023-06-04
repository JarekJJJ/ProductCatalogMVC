using Microsoft.AspNetCore.Mvc;
using ProductCatalogMVC.Application.Interfaces;

namespace ProductCatalogMVC.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IAdminService _adminService;
        public CatalogController(IItemService itemService, IAdminService adminService)
        {
            _itemService = itemService;
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            var modelItems = _itemService.GetAllItemsForList();         

            return View(modelItems);
        }
    }
}
