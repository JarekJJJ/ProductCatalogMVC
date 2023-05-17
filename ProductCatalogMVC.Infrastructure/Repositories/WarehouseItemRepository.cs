using ProductCatalogMVC.Domain.Interface;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Infrastructure.Repositories
{
    public class WarehouseItemRepository : IWarehouseItemRepository
    {
        private Context _context;
        public WarehouseItemRepository(Context context)
        {
            _context = context;
        }
        public int AddNewDelivery(WarehouseItem warehouseItems)
        {
            _context.Add(warehouseItems);
            _context.SaveChanges();
            return warehouseItems.Id;
        }
        public WarehouseItem GetItem(int itemId, int warehouseId)
        {
            var warehouseItemDetail = _context.WarehouseItems
                .FirstOrDefault(w => w.ItemId == itemId && w.WarehouseId == warehouseId);
            return warehouseItemDetail;
        }
        public IQueryable<WarehouseItem> GetItemfromAllWarehouses(int itemId)
        {
            var entity = _context.WarehouseItems.Where(w => w.ItemId == itemId);
            return entity;
        }
        public IQueryable<WarehouseItem> GetAllItems()
        {
            var entity = _context.WarehouseItems;
            return entity;
        }
        public void DeleteItemInWarehouse(WarehouseItem warehouseItem)
        {
            var entity = _context.WarehouseItems.Where(w => w.ItemId == warehouseItem.ItemId)
                .FirstOrDefault(w => w.WarehouseId == warehouseItem.WarehouseId);
            if (entity != null)
            {
                _context.WarehouseItems.Remove(entity);
                _context.SaveChanges();
            }
        }
        public void DeleteItemInAllWarehouses(int itemId)
        {
            var entity = _context.WarehouseItems.Where(w => w.ItemId == itemId);
            _context.WarehouseItems.RemoveRange(entity);
            _context.SaveChanges();
        }

        public int UpdateItemInWarehouse(WarehouseItem warehouseItem)
        {
            var entity = _context.WarehouseItems
                .FirstOrDefault(w => w.ItemId == warehouseItem.ItemId && w.WarehouseId == warehouseItem.WarehouseId);
            if (entity != null)
            {
                entity = warehouseItem;
                _context.SaveChanges();
            }
            else
            {
                return 0;
            }
            return entity.Id;

        }
    }
}
