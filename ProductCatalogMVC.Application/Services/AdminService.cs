using AutoMapper;
using ProductCatalogMVC.Application.Interfaces;
using ProductCatalogMVC.Application.ViewModels.Admin;
using ProductCatalogMVC.Application.ViewModels.Category;
using ProductCatalogMVC.Application.ViewModels.Item;
using ProductCatalogMVC.Application.ViewModels.Warehouse;
using ProductCatalogMVC.Domain.Interface;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductCatalogMVC.Application.Services
//zrobić - wysyłanie nazwy zdjęcia w folderze w widoku listofItemVm
{
    public class AdminService : IAdminService
    {
        private readonly IItemRepository _itemRepo;
        private readonly IWarehouseItemRepository _wItemRepo;
        private readonly IWarehouseRepository _warehouseRepo;
        private readonly ISupplierCategoryRepository _supplierCategoryRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        CultureInfo cultureInfo = new CultureInfo("pl-PL");

        public AdminService(IItemRepository itemRepo, IWarehouseItemRepository wItemRepo,
            IWarehouseRepository warehouseRepo, ISupplierCategoryRepository supplierCategoryRepo, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _itemRepo = itemRepo;
            _wItemRepo = wItemRepo;
            _warehouseRepo = warehouseRepo;
            _supplierCategoryRepo = supplierCategoryRepo;
            _categoryRepo = categoryRepository;
            _mapper = mapper;
        }
        public NewConnectionCategoryVm AddConnectionCategory(NewConnectionCategoryVm newConnectionCategoryVm)
        {
            var _category = _categoryRepo.GetAllCategory();
            var _items = _itemRepo.GetAllItems();
            var _wItems = _wItemRepo.GetAllItems();
            var _suppCategory = _supplierCategoryRepo.GetAllCategory();
            var _warehouses = _warehouseRepo.GetAll();

            NewConnectionCategoryVm result = new NewConnectionCategoryVm();

            result.CatalogCategoryList = new List<CatalogCategoryForListVm>();
            result.ItemsList = new List<ItemForListVm>();
            result.WarehouseItemsList = new List<WarehouseItemForListVm>();
            result.SupplierCategoryList = new List<SupplierCategoryForListVm>();
            result.WarehousesList = new List<WarehouseForListVm>();

            foreach (var catCategory in _category) //Add Catalog Category to List
            {
                var category = new CatalogCategoryForListVm()
                {
                    Id = catCategory.Id,
                    CategoryHomeId = catCategory.CategoryHomeId,
                    Name = catCategory.Name,
                    IsActive = catCategory.IsActive,
                };
                result.CatalogCategoryList.Add(category);
            }
            foreach (var item in _items) //Add Item to list
            {
                int _catId = 0;
                if (item.CategoryId != null)
                {
                    _catId = (int)item.CategoryId;
                }
                var _item = new ItemForListVm()
                {
                    Id = item.Id,
                    CategoryId = _catId,
                    Name = item.Name,
                };
                if (!item.IsDeleted)
                {
                    result.ItemsList.Add(_item);
                }
            }
            foreach (var item in _wItems)
            {
                var wItem = new WarehouseItemForListVm()
                {
                    Id = item.Id,
                    ItemId = item.ItemId,
                    SuppCategoryId = item.SuppCategoryId,
                    WarehouseId = item.WarehouseId,
                };
                result.WarehouseItemsList.Add(wItem);
            }
            foreach (var supCat in _suppCategory) // Add supplier Category to list vm
            {
                var suppCategory = new SupplierCategoryForListVm()
                {
                    Id = supCat.Id,
                    SuppCategoryId = supCat.SuppCategoryId,
                    CategoryHomeId = supCat.CategoryHomeId,
                    Name = supCat.Name,
                    WarehouseId = supCat.WarehouseId,
                };
                result.SupplierCategoryList.Add(suppCategory);
            }
            foreach (var warehouse in _warehouses)
            {
                var _warrhouse = new WarehouseForListVm()
                {
                    Id = warehouse.Id,
                    Name = warehouse.Name,
                    Description = warehouse.Description,
                };
                result.WarehousesList.Add(_warrhouse);
            }

            return result;
        }

        public NewCatalogCategoryVm AddCatalogCategory(NewCatalogCategoryVm newCatalogCategoryVm)
        {
            //var _listCC = _mapper.Map<Category>(ListOfCategory);
            var _category = _categoryRepo.GetAllCategory();
            NewCatalogCategoryVm result = new NewCatalogCategoryVm();
            result.CatalogCategoryList = new List<CatalogCategoryForListVm>();
            if (newCatalogCategoryVm.Name != null)
            {
                if (newCatalogCategoryVm.IsMainCategory == true)
                {
                    newCatalogCategoryVm.CategoryHomeId = 0;
                }
                var _newCategory = _mapper.Map<Category>(newCatalogCategoryVm);
                _categoryRepo.AddCategory(_newCategory);

            }
            foreach (var catCategory in _category)
            {
                var category = new CatalogCategoryForListVm()
                {
                    Id = catCategory.Id,
                    CategoryHomeId = catCategory.CategoryHomeId,
                    Name = catCategory.Name,
                    IsActive = catCategory.IsActive,
                };
                result.CatalogCategoryList.Add(category);
            }
            return result;


        }
        //public NewCatalogCategoryVm GetCatalogCategory()
        //{

        //    //var ListOfCategory = _categoryRepo.GetAllCategory().ToList();
        //    //var _listCC = _mapper.Map<Category>(ListOfCategory);
        //    var _category = _categoryRepo.GetAllCategory();
        //    NewCatalogCategoryVm result = new NewCatalogCategoryVm();
        //    result.CatalogCategoryList = new List<CatalogCategoryForListVm>();
        //    foreach (var catCategory in _category)
        //    {
        //        var category = new CatalogCategoryForListVm()
        //        {
        //            Id = catCategory.Id,
        //            CategoryMainId = catCategory.CategoryMainId,
        //            CategoryHomeId = catCategory.CategoryHomeId,
        //            Name = catCategory.Name,
        //            IsActive = catCategory.IsActive,
        //        };
        //        result.CatalogCategoryList.Add(category);
        //    }
        //    return result;
        //}
        public int AddWarehouse(NewWarehouseVm warehouse)
        {
            var ware = _mapper.Map<Warehouse>(warehouse);
            var id = _warehouseRepo.AddWarehouse(ware);

            return id;
        }
        public string CutIncomXmlString(string str) // funkcja potrzebna w przyszłości przy pobieraniu z adresu online
        {
            string result = str.Remove(0, 7);
            return result;
        }
        public void SaveImageFromLink(string imageUrl, string folderName)
        {
            try
            {
                string projectPath = Directory.GetCurrentDirectory(); // Pobierz ścieżkę do bieżącej lokalizacji projektu
                string newFolderPath = Path.Combine(projectPath, "ProductImage", folderName);
                Directory.CreateDirectory(newFolderPath);
                using (WebClient client = new WebClient())
                {
                    byte[] imageData = client.DownloadData(imageUrl);
                    string fileName = Guid.NewGuid().ToString() + ".jpg";
                    string filePath = System.IO.Path.Combine(newFolderPath, fileName);
                    System.IO.File.WriteAllBytes(filePath, imageData);

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void LoadItemsXML(XDocument xmlDocument)
        {
            CultureInfo cultureInfo = new CultureInfo("pl-PL");
            cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
            //cultureInfo.DefaultThreadCurrentCulture = cultureInfo;

            foreach (XElement elementXml in xmlDocument.Root.Elements("produkt"))
            {
                XElement suppCategory = elementXml.Element("grupa_towarowa");
                XElement ProductSymbol = elementXml.Element("symbol_produktu");
                XElement ProductName = elementXml.Element("nazwa_produktu");
                XElement XEanCode = elementXml.Element("ean");
                XElement ProducentName = elementXml.Element("nazwa_producenta");
                XElement ProductDescription = elementXml.Element("opis_produktu");
                XElement ImageLink = elementXml.Element("link_do_zdjecia_produktu");
                XElement ProductQuantity = elementXml.Element("stan_magazynowy");
                XElement PurchasePrice = elementXml.Element("cena");
                if (ProductName != null && XEanCode != null)
                {
                    NewItemVm itemVm = new NewItemVm();
                    NewWarehouseItemVm newWarehouseItemVm = new NewWarehouseItemVm();
                    int warehouseItemId = 0;

                    var validationItem = _itemRepo.GetAllItems().FirstOrDefault(i => i.EanCode == XEanCode.Value);
                    if (validationItem == null)
                    {
                        itemVm.Name = ProductName.Value;
                        itemVm.Symbol = ProductSymbol.Value;
                        itemVm.ImageFolderName = XEanCode.Value;
                        itemVm.EanCode = XEanCode.Value;
                        itemVm.ShortDescription = ProductDescription.Value;
                        itemVm.Producent = ProducentName.Value;
                        itemVm.IsDeleted = false;
                        itemVm.IsActive = false;
                        SaveImageFromLink(ImageLink.Value, itemVm.EanCode);
                        var newItem = _mapper.Map<Item>(itemVm);
                        var id = _itemRepo.AddItem(newItem);

                        warehouseItemId = id; //jeżeli produkt nie istnieje pobierane jest Id z nowo utworzonego
                    }
                    else
                    {
                        warehouseItemId = validationItem.Id; //Jeżeli isnieje pobierane jest z istniejącego
                    }
                    var warehouseItem = _wItemRepo.GetItem(itemVm.Id, 1);

                    if (warehouseItem == null)
                    {
                        newWarehouseItemVm.SuppCategoryId = int.Parse(suppCategory.Value);
                        newWarehouseItemVm.ItemId = warehouseItemId;
                        newWarehouseItemVm.WarehouseId = 1;
                        newWarehouseItemVm.VatRate = 23;
                        newWarehouseItemVm.Quantity = int.Parse(ProductQuantity.Value);
                        newWarehouseItemVm.NetPurchasePrice = float.Parse(PurchasePrice.Value, cultureInfo);
                        newWarehouseItemVm.IsActive = false;
                        var _newWarehouseItem = _mapper.Map<WarehouseItem>(newWarehouseItemVm);
                        var wId = _wItemRepo.AddNewDelivery(_newWarehouseItem);

                    }
                    else
                    {
                        //newWarehouseItemVm.Quantity = int.Parse(ProductQuantity.Value);
                        //newWarehouseItemVm.NetPurchasePrice = float.Parse(PurchasePrice.Value);
                        //var _newWarehouseItem = _mapper.Map<WarehouseItem>(newWarehouseItemVm);
                        //var wId = _wItemRepo.UpdateItemInWarehouse(_newWarehouseItem);

                    }


                    // _itemRepo.AddItem - zrobić mapowanie oraz zapis do warehouseItem
                }

            }
        }

        public void LoadXmlCategory(XDocument xmlDocument)
        {

            _supplierCategoryRepo.DeleteAllCategory();
            //Category category= new Category() { CategoryMainId=1, Name="Kategoria Domyślna", IsActive=false };
            //_categoryRepo.AddCategory(category);

            NewIncomSuppCategoryVm newIncomSuppCategory = new NewIncomSuppCategoryVm();
            foreach (XElement elementXml in xmlDocument.Root.Elements("grupy"))
            {
                newIncomSuppCategory.CategoryHomeId = 0;
                XElement id = elementXml.Element("id");
                XElement idh = elementXml.Element("idh");
                XElement name = elementXml.Element("name");
                if (id != null && name != null)
                {
                    newIncomSuppCategory.SuppCategoryId = int.Parse(id.Value);
                    newIncomSuppCategory.Name = name.Value;
                }
                if (idh.Value != "")
                {
                    newIncomSuppCategory.CategoryHomeId = int.Parse(idh.Value);
                }
                else
                {
                    newIncomSuppCategory.CategoryHomeId = 0;
                }
                newIncomSuppCategory.WarehouseId = 1; // wartość będzie pobierana z kontrolera
                var validationCategory = _supplierCategoryRepo.GetAllCategory().FirstOrDefault(s => s.SuppCategoryId == newIncomSuppCategory.SuppCategoryId);
                if (validationCategory == null)
                {
                    SupplierCategory vCategory = new SupplierCategory();

                    vCategory.SuppCategoryId = newIncomSuppCategory.SuppCategoryId;
                    vCategory.CategoryHomeId = newIncomSuppCategory.CategoryHomeId;
                    vCategory.WarehouseId = 1;
                    vCategory.CategoryId = 5; //Wartość domyślna (kategoria domyślna) zmieniana przez admina w widoku
                    vCategory.Name = newIncomSuppCategory.Name;
                    _supplierCategoryRepo.AddSuppCategory(vCategory);
                }
            }
        }
    }
}
