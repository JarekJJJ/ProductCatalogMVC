using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Interface
{
    public interface IWarehouseItemRepository
    {
        int AddNewDelivery(WarehouseItem warehouseItem);
        WarehouseItem GetItem(int itemId);
        IQueryable<WarehouseItem> GetItemfromAllWarehouses(int itemId);
        IQueryable<WarehouseItem> GetAll();
        void DeleteItem(int id);
        int UpdateItemInWarehouse (int id, WarehouseItem warehouseItem);
    }
}
