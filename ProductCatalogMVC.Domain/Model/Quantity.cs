using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Model
{
    public class Quantity
        //jeden do wielu z Item 
        // jeden do jeden z warehouse - ilość na danym magazynie
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int WarehouseRef { get; set; }
        public int QuantityItem { get; set; }
        public virtual Item Item { get; set; }
        public Warehouse Warehouse { get; set;}
    }
}
