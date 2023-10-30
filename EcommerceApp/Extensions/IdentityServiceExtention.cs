using Core.Context;
using Core.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace EcommerceApp.Extensions
{
    public static class IdentityServiceExtention
    {


        public static IServiceCollection AddIdentityServiceExtention(this IServiceCollection services)
        {

            var builder = services.AddIdentityCore<AppUser>();
            builder=new IdentityBuilder(builder.UserType,builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();

            return services;


        }

    }
}
