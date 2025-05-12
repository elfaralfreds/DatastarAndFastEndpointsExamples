using System.Reflection;
using FastEndpoints;
using StarFederation.Datastar.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFluid();
builder.Services.AddFastEndpoints(options => {
    options.DisableAutoDiscovery = true;
    options.Assemblies = new[]
    {
        Assembly.GetExecutingAssembly()
    };
});
builder.Services.AddDatastar();

var app = builder.Build();

app.UseStaticFiles();

app.UseFastEndpoints();

app.Run();