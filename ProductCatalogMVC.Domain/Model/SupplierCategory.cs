using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Model
{
    public class SupplierCategory
    {
        public int Id { get; set; }
        public int ViewCategoryId { get; set; }
        public int CategoryId { get; set; }
        public int CategoryHomeId { get; set; }
        public string Name { get; set; }
        public int WarehouseId { get; set; }

        public virtual Warehouse Warehouse { get; set; }
        public virtual Category Category { get; set; }
    }
}
