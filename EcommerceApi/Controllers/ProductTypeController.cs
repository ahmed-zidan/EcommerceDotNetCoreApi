using Core.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
   
    public class ProductTypeController : BaseController
    {
        private readonly IUnitOfWork _uow;
        public ProductTypeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("getTypes")]
        public async Task<IActionResult> getTypes()
        {
            var types = await _uow._typeRepo.getTypes();
            return Ok(types);
        }
    }
}
