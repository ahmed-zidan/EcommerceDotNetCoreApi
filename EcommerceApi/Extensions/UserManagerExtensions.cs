using Core.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceApi.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByEmailAndAddressAsync(this UserManager<AppUser> userManager , string email)
        {
            return await userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
