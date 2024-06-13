using Core.IRepo;
using EcommerceApi.Errors;
using Infrastructure.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace EcommerceApi.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerBasket, BasketRepo>();
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray();

                    var errorResponse = new ApiValidationErrorResponse();
                    errorResponse.Errors = errors;
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
