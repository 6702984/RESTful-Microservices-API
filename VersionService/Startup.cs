using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace VersionService
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseHsts();
            app.UseStaticFiles();
            app.UseMvc(options => options.MapRoute("default", "{controller=default}/{action=documentation}"));
            loggerFactory.AddFile(Configuration.GetSection("SerilogSettings"));
        }
    }
}