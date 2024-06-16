using AutoMapper;
using Core.IRepo;
using Core.Models.Identity;
using EcommerceApi.Dtos;
using EcommerceApi.Errors;
using EcommerceApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager, ITokenService tokenService,
            IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> login(UserLoginDto model)
        {
          
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }
            var sigin = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!sigin.Succeeded)
            {
                return Unauthorized(new ApiResponse(401));
            }
            return Ok(new UserInfoDto()
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user)
            });
        }
        [HttpPost("register")]
        public async Task<IActionResult> register(RegisterDto model)
        {

            AppUser user = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.DisplayName
            };
            var created = await _userManager.CreateAsync(user, model.Password);
            if (!created.Succeeded)
            {
                var x = created.Errors.FirstOrDefault().Description;
                return BadRequest(new ApiResponse(400, x));
            }
            return Ok() ;
        }

        [Authorize]
        [HttpGet("getCurrentUser")]
        public async Task<IActionResult> getCurrentUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?
                .Value;

            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new UserInfoDto()
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user)
            });

        }

        [HttpGet("checkEmailExist")]
        public async Task<IActionResult> checkEmailExist(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [Authorize]
        [HttpGet("getAddress")]
        public async Task<IActionResult> getAddress()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?
                .Value;
            var user = await _userManager.FindByEmailAndAddressAsync(email);
            var address = _mapper.Map<AddressDto>(user.Address);
            return Ok(address);
           
        }

        [Authorize]
        [HttpPut("updateAddress")]
        public async Task<IActionResult> updateAddress(AddressDto model)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?
                .Value;
            var user = await _userManager.FindByEmailAndAddressAsync(email);
            var address = _mapper.Map<Address>(model);

            user.Address = address;
            await _userManager.UpdateAsync(user);

            return Ok(model);

        }

    }
}
