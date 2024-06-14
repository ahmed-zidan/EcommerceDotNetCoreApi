
using Core.IRepo;
using Core.Models.Identity;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EcommerceApi.Extensions
{
    public static class IdetityServicesExtention
    {
        public static IServiceCollection AddIdentetyService(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();
            var builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<MyDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();
            var secretKey = configuration.GetSection("JwtSetting:JwtKey").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(op =>
                {
                    op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        //ValidIssuer = configuration.GetSection("JwtSetting:Issuer").Value,
                        ValidateAudience = false,
                        IssuerSigningKey = key
                    };
                });


            return services;
        }

    }
}
