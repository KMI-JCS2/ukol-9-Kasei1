using AutoMapper;
using cv09.Dtos;
using cv09.Models;

namespace cv09
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductBasicDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<PriceHistory, PriceHistoryDto>();
            CreateMap<SaleHistory, SaleHistoryDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.CustomerSurname, opt => opt.MapFrom(src => src.Customer.Surname));
            // Custom namapování na ProductName, CustomerName, CustomerSurname
        }
    }
}
