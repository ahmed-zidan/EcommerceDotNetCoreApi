using AutoMapper;
using Core.IRepo;
using EcommerceApi.Dtos;
using EcommerceApi.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork uow , IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> getProducts(string sortedBy, int brandId =0 ,int typeId = 0,int take = 10 , int skip = 0,string searchText = "")
        {
            var data = await _uow._productRepo.getProductsAsync(sortedBy , brandId , typeId , take , skip, searchText);
            var products = _mapper.Map<List<ProdeuctReturnDto>>(data);
            ProductPaginationDto dto = new ProductPaginationDto()
            {
                Producs = products,
                Count = await _uow._productRepo.count(brandId , typeId , searchText),
                PageIndex = skip,
                PageSize = products.Count()
            };
            return Ok(dto);
        }
        
        [HttpGet("getProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProdeuctReturnDto>> getProduct(int id)
        {
           
            var data = await _uow._productRepo.getProductByIdAsync(id); 
            if(data == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var product = _mapper.Map<ProdeuctReturnDto>(data);
            return Ok(product);
        }
    }
}
