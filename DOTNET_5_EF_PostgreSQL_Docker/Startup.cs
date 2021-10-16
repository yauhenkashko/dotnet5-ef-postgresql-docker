using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DOTNET_5_EF_PostgreSQL_Docker.Repository;
using DOTNET_5_EF_PostgreSQL_Docker.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DOTNET_5_EF_PostgreSQL_Docker
{
    public class Startup
    {
        public readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ShopDBContext>(o => o.UseInMemoryDatabase("Phones"));
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            services.AddTransient<IShopService, ShopService>();
            services.AddTransient<IShopRepository, ShopRepository>();

            services.AddDbContext<ShopDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
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