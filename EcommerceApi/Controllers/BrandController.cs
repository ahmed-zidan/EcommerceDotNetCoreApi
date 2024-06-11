using Core.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IUnitOfWork _uow;
        public BrandController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("getBrands")]
        public async Task<IActionResult> getBrands()
        {
            var brands = await _uow._brandRepo.getBrands();
            return Ok(brands);
        }
    }
}
