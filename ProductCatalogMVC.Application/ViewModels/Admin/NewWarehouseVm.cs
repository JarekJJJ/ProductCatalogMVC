﻿using AutoMapper;
using ProductCatalogMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Admin
{
    public class NewWarehouseVm : IMapFrom<Domain.Model.Warehouse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ShipingTime { get; set; }
        public bool IsActive { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewWarehouseVm, Domain.Model.Warehouse>();
            //Przy zapisie odwracamy kolejność mapowania !!!
        }
    }
}
