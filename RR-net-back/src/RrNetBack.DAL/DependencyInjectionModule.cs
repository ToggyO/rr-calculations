using Microsoft.Extensions.DependencyInjection;
using RrNetBack.Common.Extensions;
using RrNetBack.DAL.Repository.Users;
using RrNetBack.DAL.Repository.Users.Implementation;

namespace RrNetBack.DAL
{
    public static class DependencyInjectionModule
    {
        public static void Load(IServiceCollection services,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            services.Add<IUsersRepository, UsersRepository>(serviceLifetime);
        }
    }
}