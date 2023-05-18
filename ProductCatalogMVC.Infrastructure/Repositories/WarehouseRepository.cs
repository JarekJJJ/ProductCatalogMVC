using ProductCatalogMVC.Domain.Interface;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Infrastructure.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly Context _context;
        public WarehouseRepository(Context context)
        {
            _context = context;
        }
        public int AddWarehouse(Warehouse warehouse)
        {
            _context.Add(warehouse);
            _context.SaveChanges();
            return warehouse.Id;
        }
        public int DeleteWarehouse(int warehouseId)
        {
            var entity = _context.Warehouses.FirstOrDefault(w => w.Id == warehouseId);
            if (entity != null)
            {
                _context.Warehouses.Remove(entity);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
        public IQueryable<Warehouse> GetAll()
        {
            return _context.Warehouses;
        }
        public int UpdateWarehouse(Warehouse warehouse)
        {
            var entity = _context.Warehouses.FirstOrDefault(w => w.Id == warehouse.Id);
            if (entity != null)
            {
                entity = warehouse;
                return entity.Id;
            }
            return 0;
        }
    }
}
