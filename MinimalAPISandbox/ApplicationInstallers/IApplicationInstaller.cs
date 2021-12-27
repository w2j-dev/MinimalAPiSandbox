namespace MinimalAPISandbox.ApplicationInstallers
{
    public interface IApplicationInstaller
    {
        void InstallerServices(IServiceCollection services);
        void InstallerBuilder(WebApplication app);
    }
}
