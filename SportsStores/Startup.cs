﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportsStores.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace SportsStores
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            configuration = configuration;
        public IConfiguration configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration["Data:SportStoresProducts:ConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRespository>();
            services.AddMvc();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pagination",
                    template: "Products/Page{productPage}",
                    defaults: new "{ Controller= "Product" , action= "List" });

                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Product}/{action=List}/{id}");
            
            });
            SeedData.EnsurePopulated(app);
        }
    }
}

