using AutoMapper;
using Core.IRepo;
using Core.Models.Orders;
using EcommerceApi.Dtos;
using EcommerceApi.Errors;
using EcommerceApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public OrderController(IMapper mapper , IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        [HttpPost("createOrder")]
        public async Task<IActionResult> createOrder(CreateOrderDto model)
        {
            var address = _mapper.Map<OrderAddress>(model.shippingAddress);
            var email = HttpContext.retreiveEmailFromHttpContext();

            var order = await _uow._orderRepo.createOrderAsync(email, model.deliveryMethode, model.basketId, address);
            if(order == null)
            {
                return BadRequest(new ApiResponse(400));
            }

            return Ok(order);
        }

        [HttpGet("getOrders")]
        public async Task<IActionResult> getOrder(string email)
        {
            var orders = await _uow._orderRepo.getOrdersForUserAsync(email);

            if (orders == null)
            {
                return BadRequest(new ApiResponse(400));
            }
            
            return Ok(_mapper.Map<List<OrderToReturnDto>>(orders));
        }
        [HttpGet("getOrder")]
        public async Task<IActionResult> getOrder(int id,string email)
        {
            var order = await _uow._orderRepo.getOrderByIdAsync(id,email);
            if (order == null)
            {
                return BadRequest(new ApiResponse(400));
            }

            return Ok(_mapper.Map<OrderToReturnDto>(order));
        }
    }
}
