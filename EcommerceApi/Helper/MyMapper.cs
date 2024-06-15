using AutoMapper;
using Core.Models;
using Core.Models.Identity;
using EcommerceApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Helper
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<Product,ProdeuctReturnDto> ()
                .ForMember(x=>x.ProductBrandName , y=>y.MapFrom(src=>src.ProductBrand.Name))
                .ForMember(x=>x.ProductTypeName , y=>y.MapFrom(src=>src.ProductType.Name))
                .ForMember(x=>x.PictureUrl , y=>y.MapFrom<ProductUrlResolver>());

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>().ReverseMap();
        }
    }
}
