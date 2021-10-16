using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNET_5_EF_PostgreSQL_Docker.Repository;
using DOTNET_5_EF_PostgreSQL_Docker.Services;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_5_EF_PostgreSQL_Docker
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShopDBContext>(o => o.UseInMemoryDatabase("Phones"));
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            services.AddTransient<IShopService, ShopService>();
            services.AddTransient<IShopRepository, ShopRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(routes =>
                routes.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}")
                );
        }
    }
}