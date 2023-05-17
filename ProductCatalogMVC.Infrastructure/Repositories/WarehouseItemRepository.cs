using ProductCatalogMVC.Domain.Interface;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public WarehouseItem GetItem(int id)
        {
            var warehouseItemDetail = _context.WarehouseItems.FirstOrDefault(w => w.Id == id);
            return warehouseItemDetail;
        }
        public void DeleteItemInWarehouse(int id)
        {
            var entity = _context.WarehouseItems.FirstOrDefault(w => w.Id == id);
            if (entity != null)
            {
                _context.WarehouseItems.Remove(entity);
                _context.SaveChanges();
            }
        }

        public int UpdateItemInWarehouse(int itemId, Warehouse warehouse)
        {
            var entity = _context.Warehouses
                .SingleOrDefault(w => w.ItemId == itemId && w.Id == warehouse.Id);
            if (entity != null)
            {
                entity = warehouse;
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
