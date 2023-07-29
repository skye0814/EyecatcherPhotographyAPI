using AutoMapper;
using Core.Entities;
using Core.WebModel.Request;
using Core.WebModel.Response;

namespace EyecatcherPhotographyAPI.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryResponse>()
                .ForMember(d => d.Products, o => o.MapFrom(s => s.Products.Select(x => x.ProductName)));

            //CreateMap<PaginationFilterRequest, PaginationFilterResponse<object>>()
            //    .ForMember(d => d.PageNumber, o => o.MapFrom(s => s.PageNumber))
            //    .ForMember(d => d.PageSize, o => o.MapFrom(s => s.PageSize));


        }
    }
}
