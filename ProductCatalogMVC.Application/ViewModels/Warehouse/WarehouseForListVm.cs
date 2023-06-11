using AutoMapper;
using ProductCatalogMVC.Application.Mapping;
using ProductCatalogMVC.Application.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Warehouse
{
    public class WarehouseForListVm : IMapFrom<ProductCatalogMVC.Domain.Model.Warehouse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ShipingTime { get; set; }
        public bool IsActive { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCatalogMVC.Domain.Model.Warehouse, WarehouseForListVm>();
        }
    }
}
