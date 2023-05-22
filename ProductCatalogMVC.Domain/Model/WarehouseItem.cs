using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Model
{
    public class WarehouseItem
    // jeden do wielu z item (Jeden produkt wiele magazynów)
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public float NetPurchasePrice { get; set; }
        public float NetRetailPrice { get; set; }
        public float NetWholesalePrice { get; set; }
        public float NetSpecialPrice { get; set; }
        public float VatRate { get; set; }  
        public bool IsActive { get; set; }
        public virtual Item Item { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
