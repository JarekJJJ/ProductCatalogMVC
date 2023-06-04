using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Model
{
    public class Category
    {
        public int Id { get; set; }
      //  public int CategoryMainId { get; set; }
        public int CategoryHomeId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ItemCategory> ItemCategory { get; set; }
        public virtual ICollection<SupplierCategory> SupplierCategories { get; set; }
    }
}
