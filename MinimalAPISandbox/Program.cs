using MinimalAPISandbox;
using MinimalAPISandbox.ApplicationInstallers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointDefinitions(typeof(IEndpointDefinition));
builder.Services.AddApplicationInstallerDefinitions(typeof(IApplicationInstaller));

var app = builder.Build();
app.UseEndpointDefinitions();
app.UseHttpsRedirection();
app.UseApplicationInstallerBuilder();

app.Run();