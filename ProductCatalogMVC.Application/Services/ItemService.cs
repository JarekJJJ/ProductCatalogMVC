using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductCatalogMVC.Application.Interfaces;
using ProductCatalogMVC.Application.ViewModels.Item;
using ProductCatalogMVC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepo;
        private readonly IWarehouseItemRepository _wItemRepo;
        private readonly IWarehouseRepository _warehouseRepo;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepo, IWarehouseItemRepository wItemRepo, IWarehouseRepository warehouseRepo, IMapper mapper)
        {
            _itemRepo = itemRepo;
            _wItemRepo = wItemRepo;
            _warehouseRepo = warehouseRepo;
            _mapper = mapper;
        }

        public int AddItem(NewItemVm item)
        {
            throw new NotImplementedException();
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
        public ListItemForListVm GetAllItemsForList()
        {
            var _wItems = _wItemRepo.GetAllItems().Where(i => i.Quantity > 0);
            ListItemForListVm result = new ListItemForListVm();
            result.Items = new List<ItemForListVm>();
            foreach (var element in _wItems)
            {
                var getItem = _itemRepo.GetItemById(element.ItemId);
                var gWarehouse = _warehouseRepo.GetWarehouseById(element.WarehouseId);
                var item = new ItemForListVm()
                {
                    Id = getItem.Id,
                    Name = getItem.Name,
                    ShortDescription = getItem.ShortDescription,
                    Symbol = getItem.Symbol,
                    EanCode = getItem.EanCode,
                    Price = element.NetRetailPrice,
                    Quantity = element.Quantity,
                    ShipingTime = gWarehouse.ShipingTime,
                };
                if ((getItem.IsActive) && (gWarehouse.IsActive))
                {
                    result.Items.Add(item);
                }

            }
            result.Count = result.Items.Count;
            return result;
        }

        public ItemDetailsVm GetItemsDetails(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
