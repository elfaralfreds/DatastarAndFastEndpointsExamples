using System.Text;
using Fluid.ViewEngine;
using Microsoft.Extensions.Options;
using MinimalApis.LiquidViews;

namespace FastDatastar.Helpers;

public static class ResultExtensions
{
    // public static IResult View(this IResultExtensions result, string viewName)
    // {
    //     return new ActionViewResult(viewName);
    // }

    // public static IResult View(this IResultExtensions result, string viewName, object model)
    // {
    //     return new ActionViewResult(viewName, model);
    // }

    public static async Task<string> ViewAsString(this IResultExtensions result, HttpContext context, string viewName, object? model)
    {
        var viewResult = model == null ? new ActionViewResult(viewName) : new ActionViewResult(viewName, model);

        byte[] payload;
        using (var responseStream = new MemoryStream())
        {
            context.Response.Body = responseStream;

            await viewResult.ExecuteAsync(context);

            if(context.Response.StatusCode == 404)
            {
                throw new FluidViewNotFoundException($"View '{viewName}' not found.");
            }

            payload = responseStream.ToArray();
            payload = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(payload).Replace("\r", "").Replace("\n", ""));
            
            return Encoding.UTF8.GetString(payload);
        }
    }
}
