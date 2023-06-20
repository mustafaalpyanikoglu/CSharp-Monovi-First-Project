using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<ITokenHelper, JwtHelper>();


            return services;
        }
    }
}
