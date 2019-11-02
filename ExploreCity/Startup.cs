using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExploreCity
{
    public class Startup
        
    
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<BlogDataContext>(options =>
           {
               var connectionstring = configuration.GetConnectionString("BlogDataContext");
               options.UseSqlServer(connectionstring);
           });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler("/error.html");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();

            app.Use(async (context,next) =>
            {
                if (context.Request.Path.Value.Contains("invalid"))
                
                    throw new Exception("Error");
                    await next();
             
                    
            });
            app.UseMvc(routes=>
                {
                    routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"
                        );

            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("\nthis is dhruv!");
            //});
        }
    }
}
