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
        WarehouseItem GetItem(int itemId, int warehouseId);
        IQueryable<WarehouseItem> GetItemfromAllWarehouses(int itemId);
        IQueryable<WarehouseItem> GetAllItems();
        void DeleteItemInWarehouse(WarehouseItem warehouseItem);
        void DeleteItemInAllWarehouses(int itemId);
        int UpdateItemInWarehouse (WarehouseItem warehouseItem);
    }
}
