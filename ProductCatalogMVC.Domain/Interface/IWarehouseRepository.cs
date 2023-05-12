using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Interface
{
    public interface IWarehouseRepository
    {
        int AddNewDelivery(Warehouse warehouse);
        IQueryable<Warehouse> GetItemWarehouseDetail(int itemId);
        void DeleteItemInWarehouse(int itemId);
        int UpdateItemInWarehouse (int itemId, Warehouse warehouse);
    }
}
