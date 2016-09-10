using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using vendor.domain.data.abstracts;
using vendor.domain.entities;
using vendor.domain.data;

namespace vendor.ui.infrastructure
{
    public static class Resolver
    {
        public static void Init(IServiceCollection services)
        {
            try
            {
                services.AddScoped<IRepository<User>, Repository<User>>();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public static void AddPolicies(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("View Projects",
                    policy => policy.RequireClaim(ClaimTypes.Role, "projects.view"));
            });

            //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
        }
    }
}
