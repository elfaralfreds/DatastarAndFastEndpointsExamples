using System.Reflection;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.FileProviders;
using StarFederation.Datastar.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFluid(options => {});
builder.Services.AddFastEndpoints(options => {});
builder.Services.AddDatastar();

builder.Services.AddControllers(opt =>  // or AddMvc()
{
    // remove formatter that turns nulls into 204 - No Content responses
    // this formatter breaks Angular's Http response JSON parsing
    opt.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
});

var app = builder.Build();

app.UseStaticFiles();

app.UseFastEndpoints();

app.Run();
