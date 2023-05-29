﻿using ProductCatalogMVC.Application.ViewModels.Category;
using ProductCatalogMVC.Application.ViewModels.Item;
using ProductCatalogMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ProductCatalogMVC.Application.Interfaces
{
    public interface IAdminService
    {
        int AddWarehouse(NewWarehouseVm warehouse);
        //int AddSuppCategory(XmlDocument supplierCategory);
        void LoadXmlCategory(XDocument xmlDocument);
        void LoadItemsXML(XDocument xmlDocument);
    }
}
