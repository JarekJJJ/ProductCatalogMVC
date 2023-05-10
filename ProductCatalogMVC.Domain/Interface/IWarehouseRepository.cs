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
        public int AddNewDelivery(Warehouse warehouse);
        IQueryable<Warehouse> GetItemWarehouseDetail(int itemId);
        void DeleteItemInWarehause(int itemId);
    }
}
