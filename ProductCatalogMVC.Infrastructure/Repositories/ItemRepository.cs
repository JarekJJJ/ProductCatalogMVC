using Microsoft.EntityFrameworkCore;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Infrastructure.Repositories
{
    public class ItemRepository
    {
        private readonly Context _context;
        public ItemRepository(Context context)
        {

        }
        public IQueryable<Item> ViewItemByCategory (int categoryId)
        {
            var items = _context.Items.Include(i => i.ItemCategory)
                .ThenInclude(ic => ic.Category)
                .Where(i => i.ItemCategory.Any(ic => ic.CategoryId == categoryId)).ToList();
            return (IQueryable<Item>)items;
        }
    }
}
