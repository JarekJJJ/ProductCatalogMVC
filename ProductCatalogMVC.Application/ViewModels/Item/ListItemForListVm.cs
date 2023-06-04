using ProductCatalogMVC.Application.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Item
{
    public class ListItemForListVm
    {
        public List<ItemForListVm> Items { get; set; }
        public List<CatalogCategoryForListVm> Categories { get; set; }
        public int Count { get; set; }
    }
}
