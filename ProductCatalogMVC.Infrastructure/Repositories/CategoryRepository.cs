using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private Context _context;

        public CategoryRepository (Context context)
        {
            _context = context;
        }
    }
}
