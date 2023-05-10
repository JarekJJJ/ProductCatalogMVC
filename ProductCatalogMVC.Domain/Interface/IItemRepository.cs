using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Interface
{
    public interface IItemRepository
    {
        void PermamentDeleteItem(int itemId);
        int AddItem(Item item);
        Item GetItemById(int itemId);
        Item GetItemByEan(string eancode);
        Item GetItemBySymbol(string symbol);
        IQueryable<Item> GetItemsByCategory(int categoryId);
    }
}
