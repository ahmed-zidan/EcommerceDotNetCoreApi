using AutoMapper;
using Core.Models;
using EcommerceApi.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Helper
{
    public class ProductUrlResolver : IValueResolver<Product, ProdeuctReturnDto, string>
    {
        private readonly IConfiguration _configuration;
        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProdeuctReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }
            else
            {
                return _configuration["ApiUrl"] + "images/products/sb-ang1.png";
            }
        }
    }
}
