using AutoMapper;
using ProductCatalogMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Category
{
    public class SupplierCategoryForListVm : IMapFrom<ProductCatalogMVC.Domain.Model.SupplierCategory>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; } // Catalog CategoryId
        public int SuppCategoryId { get; set; } //SupplierCategory
        public int CategoryHomeId { get; set; } // Supplier Main Category
        public string Name { get; set; }    //Category Name
        public int WarehouseId { get; set; } // Supplier Id
        public int CountWarehouseItem { get; set; } //Additional property
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCatalogMVC.Domain.Model.SupplierCategory, SupplierCategoryForListVm>();
        }
    }
}
