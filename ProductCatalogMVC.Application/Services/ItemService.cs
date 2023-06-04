using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductCatalogMVC.Application.Interfaces;
using ProductCatalogMVC.Application.ViewModels.Category;
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
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepo, IWarehouseItemRepository wItemRepo, IWarehouseRepository warehouseRepo, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _itemRepo = itemRepo;
            _wItemRepo = wItemRepo;
            _warehouseRepo = warehouseRepo;
            _categoryRepo = categoryRepository;
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
        public ListItemForListVm GetAllItemsForList()
        {
            var _wItems = _wItemRepo.GetAllItems().Where(i => i.Quantity > 0);
            var _category = _categoryRepo.GetAllCategory();
            ListItemForListVm result = new ListItemForListVm();
            result.Items = new List<ItemForListVm>();
            result.Categories = new List<CatalogCategoryForListVm>();
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
                    Price = element.NetPurchasePrice,
                    Quantity = element.Quantity,
                    ShipingTime = gWarehouse.ShipingTime,
                };
                string folderPath = Directory.GetCurrentDirectory(); // pobiera folder projektu                
                string imgPath = $"{folderPath}/ProductImage/{item.EanCode}"; // tworzy ścieżkę do folderu ze zdjęciami
                string[] imageFiles = Directory.GetFiles(imgPath, "*.jpg"); // pobiera do tablicy wszystkie zdjęcia z folderu
                
                var imagePath = imageFiles.FirstOrDefault();
                var singleImagePath = Path.GetFileName(imagePath);
                item.ImgMainPath = singleImagePath;    
                //if ((getItem.IsActive) && (gWarehouse.IsActive))
                //  {
                result.Items.Add(item);
              //  }
              

            }
            foreach (var catCategory in _category)
            {
                var category = new CatalogCategoryForListVm()
                {
                    Id= catCategory.Id,
                   // CategoryMainId = catCategory.CategoryMainId,
                    CategoryHomeId = catCategory.CategoryHomeId,
                    Name = catCategory.Name,
                    IsActive = catCategory.IsActive,
                };
                result.Categories.Add(category);
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
