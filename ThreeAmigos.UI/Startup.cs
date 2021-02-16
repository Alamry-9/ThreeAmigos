using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThreeAmigos.Domain.Entities;
using ThreeAmigos.Domain.Interfaces.Repositories;
using ThreeAmigos.Domain.Interfaces.Services;
using ThreeAmigos.Domain.Services;
using ThreeAmigos.Persistance;
using ThreeAmigos.Persistance.Repositories;

namespace ThreeAmigos.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ThreeAmigosDbContect>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRepository<Product>, BaseRepository<Product>>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IRepository<Brand>, BaseRepository<Brand>>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRepository<Category>, BaseRepository<Category>>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IRepository<Student>, BaseRepository<Student>>();

            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
