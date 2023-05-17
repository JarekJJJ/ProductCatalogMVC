using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Model
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ShipingTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
    }
}
