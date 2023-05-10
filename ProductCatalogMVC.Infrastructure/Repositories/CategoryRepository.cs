using ProductCatalogMVC.Domain.Interface;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public int AddCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return category.Id;
        }
    }
}
