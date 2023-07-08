﻿using AutoMapper;
using Core.Entities;

namespace EyecatcherPhotographyAPI.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryResponse>()
                .ForMember(d => d.Products, o => o.MapFrom(s => s.Products.Select(x => x.ProductName)));
        }
    }
}
