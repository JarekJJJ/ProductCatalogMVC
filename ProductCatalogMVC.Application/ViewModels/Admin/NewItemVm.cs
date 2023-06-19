using AutoMapper;
using ProductCatalogMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogMVC.Application.ViewModels.Admin
{
    public class NewItemVm : IMapFrom<Domain.Model.Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Symbol { get; set; }
        public string EanCode { get; set; }
        public string Producent { get; set; }
        public string ImageFolderName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Item, NewItemVm>();
        }

    }
}
