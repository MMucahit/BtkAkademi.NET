using Business.Abstracts;
using Business.Concrete;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
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

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
               
                options.User.RequireUniqueEmail = true;
                
                options.Password.RequiredLength = 10;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
            }).AddEntityFrameworkStores<RepositoryContext>();
        }
    }
}