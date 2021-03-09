using Microsoft.Extensions.DependencyInjection;
using RrNetBack.API.Handlers.Users;
using RrNetBack.API.Handlers.Users.Implementation;
using RrNetBack.BLL;
using RrNetBack.Common.Extensions;

namespace RrNetBack.API
{
    public class DependencyInjectionModule
    {
        public static void Load(IServiceCollection services,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            BLL.DependencyInjectionModule.Load(services, serviceLifetime);
            
            services.Add<IUsersHandler, UsersHandler>(serviceLifetime);
        }
    }
}