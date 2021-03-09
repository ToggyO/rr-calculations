using Microsoft.Extensions.DependencyInjection;
using RrNetBack.BLL.Services.Retention;
using RrNetBack.BLL.Services.Retention.Implementation;
using RrNetBack.Common.Extensions;

namespace RrNetBack.BLL
{
    public class DependencyInjectionModule
    {
        public static void Load(IServiceCollection services,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            DAL.DependencyInjectionModule.Load(services, serviceLifetime);
         
            services.Add<IRetentionService, RetentionService>(serviceLifetime);
        }
    }
}