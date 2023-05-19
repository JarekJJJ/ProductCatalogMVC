﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Item
{
    public class ItemForListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Symbol { get; set; }
        public string EanCode { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int ShipingTime { get; set; }

    }
}
