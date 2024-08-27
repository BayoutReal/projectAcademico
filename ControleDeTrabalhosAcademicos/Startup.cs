using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ControleDeTrabalhosAcademicos.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDeTrabalhosAcademicos
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
            // Register the application's DbContext with dependency injection, using SQL Server.
            services.AddDbContext<TrabalhosContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            // Register MVC services with support for controllers and views.
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Conditionally configure middleware based on the environment.
            if (env.IsDevelopment())
            {
                // Use the detailed error page in the development environment.
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Use the custom error handler and HSTS in production.
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Conditionally use HTTPS redirection, avoiding it in Docker and development environments.
            if (!env.IsDevelopment() && !env.IsEnvironment("Docker"))
            {
                app.UseHttpsRedirection();
            }

            // Serve static files such as HTML, CSS, images, etc.
            app.UseStaticFiles();

            // Enable routing for the application.
            app.UseRouting();

            // Enable the authorization middleware.
            app.UseAuthorization();

            // Configure endpoint routing for MVC controllers.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
