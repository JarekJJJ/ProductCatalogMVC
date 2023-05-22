using ProductCatalogMVC.Domain.Interface;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Infrastructure.Repositories
{
    public class SupplierCategoryRepository : ISupplierCategoryRepository
    {
        private Context _context;
        public SupplierCategoryRepository(Context context)
        {
            _context = context;
        }
        public int AddCategory(SupplierCategory supplierCategory)
        {
            _context.Add(supplierCategory);
            _context.SaveChanges();
            return supplierCategory.Id;
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

        public IQueryable<SupplierCategory> GetAllCategory()
        {
            var category = _context.supplierCategories;
            return category;
        }

        public int UpdateCategory(SupplierCategory supplierCategory)
        {
            var entity = _context.supplierCategories.Find(supplierCategory.Id);
            if (entity != null)
            {
                entity = supplierCategory;
                _context.SaveChanges();
            }
            return supplierCategory.Id;
        }
    }
}
