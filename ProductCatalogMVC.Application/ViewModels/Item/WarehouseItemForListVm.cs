using AutoMapper;
using ProductCatalogMVC.Application.Mapping;
using ProductCatalogMVC.Application.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Item
{
    public class WarehouseItemForListVm : IMapFrom<ProductCatalogMVC.Domain.Model.WarehouseItem>
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int SuppCategoryId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCatalogMVC.Domain.Model.WarehouseItem, WarehouseItemForListVm>();
        }
    }
}
