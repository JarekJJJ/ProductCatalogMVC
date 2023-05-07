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
        public int ItemId { get; set; }
        //public int Quantity { get; set; }
        public decimal NetPurchasePrice { get; set; }
        public int ShipingTime { get; set; }
        public virtual Item Item { get; set; }
        public Price Price { get; set; }
        public Quantity Quantity { get; set; }

    }
}
