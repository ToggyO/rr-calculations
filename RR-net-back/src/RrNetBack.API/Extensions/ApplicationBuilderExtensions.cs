using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RrNetBack.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void EnsureMigrationContext<T>(this IApplicationBuilder app) where T : DbContext
        {
            try
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<T>();
                    context.Database.Migrate();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}