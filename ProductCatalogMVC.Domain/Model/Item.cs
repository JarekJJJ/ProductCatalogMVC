using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Model
{
    public class Item
    //Jeden do wielu z Cenami, Ilością, Magazynem
    // (Logika sprawdza z którego magazynu pochodzi produkt
    //ustala cenę oraz  ilość na podstawie ceny od dostawcy - magazynu zewnętrzengo
    // Wiele do wielu z kategoriami - produkt może posiadać kilka kategorii , kategorie posiadają
    // wiele produktów
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Symbol { get; set; }
        public string EanCode { get; set; }
        public string Producent { get; set; }
        public string ImageFolderName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ItemCategory> ItemCategory { get; set; }
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
    }
}
