﻿using AutoMapper;
using Core.IRepo;
using Core.Models;
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
   
    public class BasketController : BaseController
    {
        private readonly ICustomerBasket _basket;
        private readonly IMapper _mapper;
        public BasketController(ICustomerBasket basket, IMapper mapper)
        {
            _basket = basket;
            _mapper = mapper;
        }

        [HttpGet("getBasket/{id}")]
        public async Task<IActionResult> getBasket(string id)
        {
            var basket = await _basket.getBasket(id);
           
            return Ok(basket ?? new CustomerBasket(id));
           
        }

        [HttpPut("updateBasket")]
        public async Task<IActionResult> updateBasket(CustomerBasketDto model)
        {
            var bask = _mapper.Map<CustomerBasket>(model);
            var basket = await _basket.updateBasket(bask);
            if (basket != null)
            {
                return Ok(basket);
            }
            else
            {
                return BadRequest(new ApiResponse(400, "Bad Request"));
            }
        }

        [HttpDelete("deleteBasket/{id}")]
        public async Task<IActionResult> deleteBasket(string id)
        {
            var deleted = await _basket.deleteBasket(id);
            if (deleted)
            {
                return Ok();
            }
            else
            {
                return NotFound(new ApiResponse(400, "Bad Request"));
            }
        }


    }
}
