using AutoMapper;
using ProductCatalogMVC.Application.Mapping;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Category
{
    public class NewIncomSuppCategoryVm : IMapFrom<ProductCatalogMVC.Domain.Model.SupplierCategory>
    {
        public int Id { get; set; }
        public int ViewCategoryId { get; set; }
        public int SuppCategoryId { get; set; }
        public int CategoryHomeId { get; set; }
        public string Name { get; set; }
        public int WarehouseId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewIncomSuppCategoryVm, ProductCatalogMVC.Domain.Model.SupplierCategory>();
        }
    }
}
