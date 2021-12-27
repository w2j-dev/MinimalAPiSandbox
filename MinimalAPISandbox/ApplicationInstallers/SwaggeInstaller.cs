using Microsoft.OpenApi.Models;

namespace MinimalAPISandbox.ApplicationInstallers
{
    public class SwaggeInstaller : IApplicationInstaller
    {
        public void InstallerBuilder(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal.API.Sample"));
        }

        public void InstallerServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { 
                    Title = "Minimal.API.Sample",
                    Version = "v1",
                    Description="Description Minimal API" 
                });
            });
        }
    }
}
