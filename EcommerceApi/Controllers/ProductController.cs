using Infrastructure.IRepo;
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
        public ProductController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> getProducts()
        {
            var data = await _uow._productRepo.getProducts();
            return Ok(data);
        }

        [HttpGet("getProduct/{id}")]
        public async Task<IActionResult> getProduct(int id)
        {
            var data = await _uow._productRepo.getProductById(id);
            return Ok(data);
        }
    }
}
