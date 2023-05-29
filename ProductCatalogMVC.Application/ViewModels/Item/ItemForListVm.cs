using AutoMapper;
using ProductCatalogMVC.Application.Mapping;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Item
{
    public class ItemForListVm : IMapFrom<ProductCatalogMVC.Domain.Model.Item>,
                                IMapFrom<ProductCatalogMVC.Domain.Model.WarehouseItem>,
                                IMapFrom<ProductCatalogMVC.Domain.Model.Warehouse>
    {
        public int Id { get; set; }//Pozycje z modelu Item
        public string Name { get; set; } //Pozycje z modelu Item
        public string ShortDescription { get; set; } //Pozycje z modelu Item
        public string Symbol { get; set; }//Pozycje z modelu Item
        public string EanCode { get; set; }//Pozycje z modelu Item
        public string Producent { get; set; } // Item
        public bool IsActive { get; set; } // ---||-----
        public float Price { get; set; }//pozycja z modelu ItemWarehouse
        public int Quantity { get; set; } //pozycja z modelu ItemWarehouse
        public int ShipingTime { get; set; } // Pozycja z modelu Warehouse
        public bool IsActiveWar { get; set; } // -----||------

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCatalogMVC.Domain.Model.Item, ItemForListVm>();
            profile.CreateMap<ProductCatalogMVC.Domain.Model.WarehouseItem, ItemForListVm>()
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.NetRetailPrice));
            profile.CreateMap<ProductCatalogMVC.Domain.Model.Warehouse, ItemForListVm>()
                .ForMember(d => d.IsActiveWar, opt => opt.MapFrom(s => s.IsActive));
        }
    }
}
