using ProductCatalogMVC.Application.ViewModels.Category;
using ProductCatalogMVC.Application.ViewModels.Item;
using ProductCatalogMVC.Application.ViewModels.Warehouse;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Admin
{
    public class NewConnectionCategoryVm
    {
        public int Id { get; set; } 
        public int ItemId { get; set; } //item
        public int CategoryId { get; set; } //item
        public List<CatalogCategoryForListVm> CatalogCategoryList { get; set; }
        public List<ItemForListVm> ItemsList { get; set; }
        public List<SupplierCategoryForListVm> SupplierCategoryList { get; set; }
        public List<WarehouseItemForListVm> WarehouseItemsList { get; set; }
        public List<WarehouseForListVm> WarehousesList { get; set; }      

    }
}
