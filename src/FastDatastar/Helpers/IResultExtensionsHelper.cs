using System.Text;
using MinimalApis.LiquidViews;

public static class ResultExtensions
{
    public static async Task<string> ViewAsString(this IResultExtensions result, HttpContext context, string viewName, object? model)
    {
        var viewResult = model == null ? new ActionViewResult(viewName) : new ActionViewResult(viewName, model);

        byte[] payload;
        using(var responseStream = new MemoryStream())
        {
            context.Response.Body = responseStream;

            await viewResult.ExecuteAsync(context);
            
            payload = responseStream.ToArray();
            payload = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(payload).Replace("\r", "").Replace("\n", ""));
            return Encoding.UTF8.GetString(payload); 
        }
        
    }
}