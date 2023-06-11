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
        public int CategoryId { get; set; } //CatalogCategory
        public int SuppCategoryId { get; set; } //SupplierCategory
        public int CategoryHomeId { get; set; } // Supplier Main Category
        public string Name { get; set; }
        public int WarehouseId { get; set; } // Supplier Id

        public virtual Warehouse Warehouse { get; set; }
        public virtual Category Category { get; set; }
    }
}
