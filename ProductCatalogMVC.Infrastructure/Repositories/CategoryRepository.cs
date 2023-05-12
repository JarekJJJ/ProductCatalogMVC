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

        public void DeleteCategory(int id)
        {
           var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
               
            }
        }

        public IQueryable<Category> GetAllCategory()
        {
            var category = _context.Categories;
            return category;
        }

        public int UpdateCategory(Category category)
        {
           var entity = _context.Categories.Find(category.Id);
            if (entity != null)
            {
                entity = category;
                _context.SaveChanges();
            }
            return category.Id;
        }
    }
}
