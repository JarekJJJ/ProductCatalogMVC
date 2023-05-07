using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Model
{
    public class Price
    //jeden do wielu z Item
    // jeden do jeden z warehouse
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int WarehouseRef { get; set; }
        public decimal NetRetailPrice { get; set; }
        public decimal NetWholesalePrice { get; set; }
        public decimal NetSpecialPrice { get; set; }
        public decimal VatRate { get; set; }
        public virtual Item Item { get; set; }
        public Warehouse Warehouse { get; set; }

    }
}
