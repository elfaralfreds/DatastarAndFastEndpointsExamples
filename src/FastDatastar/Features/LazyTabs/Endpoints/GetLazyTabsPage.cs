
using FastEndpoints;

public class GetLazyTabsPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/lazy-tabs");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/LazyTabs", new { }).ExecuteAsync(this.HttpContext);
    }
}