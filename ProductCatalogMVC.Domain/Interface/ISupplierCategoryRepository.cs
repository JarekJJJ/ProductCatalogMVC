﻿using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Domain.Interface
{
    public interface ISupplierCategoryRepository
    {
        int AddCategory(SupplierCategory supplierCategory);
        IQueryable<SupplierCategory> GetAllCategory();
        int UpdateCategory(SupplierCategory supplierCategory);
        void DeleteCategory(int id);
    }
}
