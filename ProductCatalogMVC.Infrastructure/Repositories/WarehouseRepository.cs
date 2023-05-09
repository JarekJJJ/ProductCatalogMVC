﻿using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Infrastructure.Repositories
{
    public class WarehouseRepository
    {
        private Context _context;
        public WarehouseRepository(Context context)
        {
            _context = context;
        }
        public int AddNewDelivery (Warehouse warehouse)
        {
            _context.Add(warehouse);
            _context.SaveChanges();
            return warehouse.Id;
        }
        public IQueryable<Warehouse> GetItemWarehouseDetail(int itemId)
        {
            var warehouseDetail = _context.Warehouses.Where(w => w.ItemId == itemId);
            return warehouseDetail;
        }
        public void DeleteWarehause(int itemId)
        {
          var warehouse = _context.Warehouses.Where(w => w.ItemId == itemId);
            if(warehouse !=null)
            {
                _context.Warehouses.RemoveRange(warehouse);
                _context.SaveChanges();
            }
        }
            
    }
}
