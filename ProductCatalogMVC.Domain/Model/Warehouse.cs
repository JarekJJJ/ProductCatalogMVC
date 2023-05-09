using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Model
{
    public class Warehouse
        //jeden do jeden z ceną, ilością (każdy magazyn może mieć inną cenę i ilość danego produktu)
        // jeden do wielu z item (Jeden produkt wiele magazynów)
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal NetPurchasePrice { get; set; }
        public decimal NetRetailPrice { get; set; }
        public decimal NetWholesalePrice { get; set; }
        public decimal NetSpecialPrice { get; set; }
        public decimal VatRate { get; set; }
        public int ShipingTime { get; set; }
        public virtual Item Item { get; set; }
      

    }
}
