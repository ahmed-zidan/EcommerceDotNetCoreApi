using AutoMapper;
using Core.IRepo;
using EcommerceApi.Dtos;
using EcommerceApi.Errors;
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
        public async Task<IActionResult> getProducts()
        {
            var data = await _uow._productRepo.getProductsAsync();
            var products = _mapper.Map<List<ProdeuctReturnDto>>(data);
            return Ok(products);
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
