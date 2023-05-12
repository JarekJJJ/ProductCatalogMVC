using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Interface
{
    public interface ICategoryRepository
    {
        int AddCategory(Category category);
        IQueryable<Category> GetAllCategory();
        int UpdateCategory(Category category);
        void DeleteCategory(int categoryId);

    }
}
