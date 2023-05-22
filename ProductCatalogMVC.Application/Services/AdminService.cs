using AutoMapper;
using ProductCatalogMVC.Application.Interfaces;
using ProductCatalogMVC.Application.ViewModels.Item;
using ProductCatalogMVC.Domain.Interface;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IItemRepository _itemRepo;
        private readonly IWarehouseItemRepository _wItemRepo;
        private readonly IWarehouseRepository _warehouseRepo;
        private readonly IMapper _mapper;
        public AdminService(IItemRepository itemRepo, IWarehouseItemRepository wItemRepo, IWarehouseRepository warehouseRepo, IMapper mapper)
        {
            _itemRepo = itemRepo;
            _wItemRepo = wItemRepo;
            _warehouseRepo = warehouseRepo;
            _mapper = mapper;
        }
        //public ListItemForListVm GetAllItemsForList() //
        //{
        //    var _items = _itemRepo.GetAllItems()
        //        .ProjectTo<ItemForListVm>(_mapper.ConfigurationProvider);
        //        //.Where(a => a.IsActive == true && a.IsActiveWar == true && a.Quantity > 0);
        //    var itemList = new ListItemForListVm()
        //    {
        //        Items = _items.ToList(),
        //        Count = _items.Count()
        //    };

        //    return itemList;

        //}
        public int AddWarehouse(NewWarehouseVm warehouse)
        {
            var ware = _mapper.Map<Warehouse>(warehouse);
            var id = _warehouseRepo.AddWarehouse(ware);

            return id;
        }
    }
}
