using AutoMapper;
using ProductCatalogMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Item
{
    public class NewWarehouseItemVm : IMapFrom<ProductCatalogMVC.Domain.Model.WarehouseItem>
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int SuppCategoryId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public float NetPurchasePrice { get; set; }
        public float NetRetailPrice { get; set; }
        public float NetWholesalePrice { get; set; }
        public float NetSpecialPrice { get; set; }
        public float VatRate { get; set; }
        public bool IsActive { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewWarehouseItemVm, ProductCatalogMVC.Domain.Model.WarehouseItem>();
        }
    }
}
