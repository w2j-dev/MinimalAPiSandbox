namespace MinimalAPISandbox.ApplicationInstallers
{
    public static class ApplicationInstallerExtensions
    {
        public static void AddApplicationInstallerDefinitions(
            this IServiceCollection services, params Type[] scanMarkers)
        {
            var endpointDefinitions = new List<IApplicationInstaller>();

            foreach (var marker in scanMarkers)
            {
                endpointDefinitions.AddRange(
                    marker.Assembly.ExportedTypes
                        .Where(x => typeof(IApplicationInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                        .Select(Activator.CreateInstance).Cast<IApplicationInstaller>()
                );
            }

            foreach (var endpointDefinition in endpointDefinitions)
            {
                endpointDefinition.InstallerServices(services);
            }

            services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IApplicationInstaller>);
        }

        public static void UseApplicationInstallerBuilder(this WebApplication app)
        {
            var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IApplicationInstaller>>();

            foreach (var endpointDefinition in definitions)
            {
                endpointDefinition.InstallerBuilder(app);
            }
        }
    }
}
