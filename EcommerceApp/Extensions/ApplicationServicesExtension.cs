using InfraStructure.Interfaces;
using InfraStructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services.Services.ProductService.Dto;
using Services.Services.ProductService;
using EcommerceApp.HandelResponses;
using Services.Services.CacheService;
using Services.Services.BasketService.DTO;
using InfraStructure.BasketRepository;
using Services.Services.BasketService;

namespace EcommerceApp.Extensions
{
    public static class ApplicationServicesExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {


            //IGenericRepository : BaseEntity where BaseEntity is Product||ProductBrand||ProductType
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketService, BasketService>();

            services.AddAutoMapper(typeof(ProductProfile));
            services.AddAutoMapper(typeof(BasketProfile));
            
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(model => model.Value.Errors.Count > 0)
                    .SelectMany(error => error.Value.Errors)
                    .Select(err => err.ErrorMessage)
                    .ToList();


                    var errorResponse = new ApiValidationErrorResponse { Errors = errors };

                    return new BadRequestObjectResult(errorResponse);
                };
            });


            return services;
        }
    }
}
