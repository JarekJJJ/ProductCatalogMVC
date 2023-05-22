using ProductCatalogMVC.Application.ViewModels.Item;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.Interfaces
{
    public interface IAdminService
    {
        int AddWarehouse(NewWarehouseVm warehouse);
    }
}
