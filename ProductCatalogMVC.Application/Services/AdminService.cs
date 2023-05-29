using AutoMapper;
using ProductCatalogMVC.Application.Interfaces;
using ProductCatalogMVC.Application.ViewModels.Category;
using ProductCatalogMVC.Application.ViewModels.Item;
using ProductCatalogMVC.Domain.Interface;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductCatalogMVC.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IItemRepository _itemRepo;
        private readonly IWarehouseItemRepository _wItemRepo;
        private readonly IWarehouseRepository _warehouseRepo;
        private readonly ISupplierCategoryRepository _supplierCategoryRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        public AdminService(IItemRepository itemRepo, IWarehouseItemRepository wItemRepo,
            IWarehouseRepository warehouseRepo,ISupplierCategoryRepository supplierCategoryRepo, ICategoryRepository categoryRepository ,IMapper mapper)
        {
            _itemRepo = itemRepo;
            _wItemRepo = wItemRepo;
            _warehouseRepo = warehouseRepo;
            _supplierCategoryRepo = supplierCategoryRepo;
            _categoryRepo= categoryRepository;
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
        public string CutIncomXmlString (string str) // funkcja potrzebna w przyszłości przy pobieraniu z adresu online
        {
            string result = str.Remove(0, 7);
                return result;
        }
        public void SaveImageFromLink (string imageUrl, string folderName)
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
                   NewItemVm itemVm= new NewItemVm();
                    
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
                        itemVm.IsActive= false;
                        SaveImageFromLink(ImageLink.Value, itemVm.EanCode);
                        var newItem = _mapper.Map<Item>(itemVm);
                        var id = _itemRepo.AddItem(newItem);

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
            
            //dorobić zapisywanie w bazie !!!!

            //var incomXml = xmlDocument.Root.Elements("grupy");
            //

            //foreach (var elementXml in incomXml) 
            //{

            //    newIncomSuppCategory.CategoryId = int.Parse((elementXml.Element("grupy").Element("id")).ToString());
            //}

            
        }
    }
}
