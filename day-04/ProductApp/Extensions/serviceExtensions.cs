using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;

namespace ProductApp.Extensions
{
    public static class serviceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>
            (options => options.UseSqlServer
            (configuration.GetConnectionString
            ("sqlconnection")));
        }
    }
}
