﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;

namespace SportsStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Configuration["Data:SportsStoreProducts:ConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRepository>();
            //services.AddTransient<IProductRepository, FakeProductRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    null,
                    "{category}/Page{productPage:int}",
                    new {controller = "Product", action = "List"}
                );

                routes.MapRoute(
                    null,
                    "Page{productPage:int}",
                    new
                    {
                        controller = "Product",
                        action = "List", productPage = 1
                    }
                );

                routes.MapRoute(
                    null,
                    "{category}",
                    new
                    {
                        controller = "Product",
                        action = "List", productPage = 1
                    }
                );

                routes.MapRoute(
                    null,
                    "",
                    new
                    {
                        controller = "Product", action = "List",
                        productPage = 1
                    });
                routes.MapRoute(null, "{controller}/{action}/{id?}");
            });
            //SeedData.EnsurePopulated(app);
        }
    }
}