using AutoMapper;
using Core.Models.Orders;
using EcommerceApi.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Helper
{
    public class OrderUrlResolver : IValueResolver<OrderItem, OrderItemToReturnDto, string>
    {
        private readonly IConfiguration _configuration;
        public OrderUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProductItemOrder.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.ProductItemOrder.PictureUrl;
            }
            else
            {
                return _configuration["ApiUrl"] + "images/products/sb-ang1.png";
            }
        }
    }
}
