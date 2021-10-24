using DigitalZooProject.Data;
using DigitalZooProject.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalZooProject
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository, MyRepository>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ZooContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, ZooContext ctx)
        {
            app.UseDeveloperExceptionPage();

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
