using Microsoft.EntityFrameworkCore;
using ProductCatalogMVC.Domain.Interface;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly Context _context;
        public ItemRepository(Context context)
        {
            _context = context;
        }
        public void DeleteItem(int itemId)
        {
            var item = _context.Items.Find(itemId);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }
        public int AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item.Id;
        }
        public Item GetItemById(int itemId)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == itemId);
            return item;
        }
        public Item GetItemByEan(string eancode)
        {
            var item = _context.Items.FirstOrDefault(x => x.EanCode == eancode);
            return item;
        }
        public Item GetItemBySymbol(string symbol)
        {
            var item = _context.Items.FirstOrDefault(x => x.Symbol == symbol);
            return item;
        }

        public IQueryable<Item> GetItemsByCategory(int categoryId)
        {
            var items = _context.Items.Include(i => i.ItemCategory)
                .ThenInclude(ic => ic.Category)
                .Where(i => i.ItemCategory.Any(ic => ic.CategoryId == categoryId));
            return items;
        }

        public IQueryable<Item> GetAllItems()
        {
            var items = _context.Items;

            return items;
        }

        public int UpdateItem(Item item)
        {
            var _item = _context.Items.FirstOrDefault(i => i.Id == item.Id);
            return _item.Id;
        }
    }
}
