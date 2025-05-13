namespace FastDatastar.Helpers;

public static class HttpContextExtensions
{
    public static HttpContext Duplicate(this HttpContext self)
    {
        var context = new DefaultHttpContext();
        context.RequestServices = self.RequestServices;
        return context;
    }
}