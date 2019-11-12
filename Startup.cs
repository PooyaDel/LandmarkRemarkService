using LandmarkRemarkService.WorkerClasses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LandmarkRemarkService
{
    public class Startup
    {
        readonly string AllowCORS = "AllowCORS";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            
            // Dependency injection of the LandmarkOperation class.
            services.AddTransient<ILandmarkOperation, LandmarkOperation>();

            

            services.AddTransient<IUserLogin, UserLogin>();

            //  Add for Cross-origin resource sharing
            services.AddCors(options => options.AddPolicy(AllowCORS, builder =>
            {
                builder.AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowAnyHeader();
            }));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            loggerFactory.AddLog4Net();

            // Use CORS policy degined in ConfigureServices function
            app.UseCors(AllowCORS);
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
