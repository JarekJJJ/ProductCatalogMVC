using ProductCatalogMVC.Application.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.Interfaces
{
    public interface IItemService
    {
        ListItemForListVm GetAllItemsForList();
        int AddItem(NewItemVm item);
        ItemDetailsVm GetItemsDetails(int itemId);
    }
}
