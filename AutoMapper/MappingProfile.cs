using AutoMapper;
using ProductInventoryApi.Models;
using ProductInventoryApi.Models.DTOs;
namespace ProductInventoryApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>();
        }
    }
}
