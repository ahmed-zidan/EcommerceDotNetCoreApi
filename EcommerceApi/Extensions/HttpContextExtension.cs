using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceApi.Extensions
{
    public static class HttpContextExtension
    {
        public static string retreiveEmailFromHttpContext(this HttpContext context)
        {
            return context?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
        }
    }
}
