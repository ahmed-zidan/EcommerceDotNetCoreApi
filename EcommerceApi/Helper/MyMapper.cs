using AutoMapper;
using Core.Models;
using Core.Models.Identity;
using Core.Models.Orders;
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
            CreateMap<AddressDto, OrderAddress>().ReverseMap();
            CreateMap<OrderItem, OrderItemToReturnDto>().
                ForMember(x => x.ProductId, y => y.MapFrom(src => src.ProductItemOrder.ProductId)).
                ForMember(x => x.ProductName, y => y.MapFrom(src => src.ProductItemOrder.ProductName)).
                ForMember(x => x.PictureUrl, y => y.MapFrom<OrderUrlResolver>());
               
            CreateMap<Order, OrderToReturnDto>().
                ForMember(x => x.Total, src => src.MapFrom(dst => dst.getTotal()))
                ;
        }
    }
}
