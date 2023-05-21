using Microsoft.AspNetCore.Mvc;
using ProductCatalogMVC.Application.Interfaces;

namespace ProductCatalogMVC.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IItemService _itemService;
        public CatalogController(IItemService itemService)
        {
            _itemService = itemService;
        }
        public IActionResult Index()
        {
            var model = _itemService.GetAllItemsForList();
            return View(model);
        }
    }
}
