using AutoMapper;
using ProductCatalogMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Category
{
    public class CatalogCategoryForListVm : IMapFrom<ProductCatalogMVC.Domain.Model.Category>
    {
        public int Id { get; set; }
        public int CategoryMainId { get; set; }
        public int CategoryHomeId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CatalogCategoryForListVm, ProductCatalogMVC.Domain.Model.Category>();
        }
    }
}
