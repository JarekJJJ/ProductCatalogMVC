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
        int AddWarehouse(Warehouse warehouse);
        IQueryable<Warehouse> GetAll();
        int UpdateWarehouse(Warehouse warehouse);
        int DeleteWarehouse(int warehouseId);
        Warehouse GetWarehouseById(int id);

    }
}
