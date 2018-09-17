using ImportCars.BusinessLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ImportCars
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add all the services that the MVC subsystem needs
            services.AddMvc();
            services.AddScoped<IImportVehicleInfo, ImportVehicleFromCsv>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseNodeModules(env);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            // Set the other of middlewhere layer and the order matters.

            // UseDefaultFiles will allow you to access to the default fileswithout adding the route in the url.
            // e.g: localhost:[portt] will return index.html
            // app.UseDefaultFiles(); // Removed because we are not serving default files, we will serve using MVC

            // Tell the web service using satic files is something we can do. 
            // Those static files must bounder the wwwroot folder
            app.UseStaticFiles();

            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default", "/{controller}/{action}/{id?}",
                    new { Controller = "App", Action = "Index" });
            });
        }
    }
}
