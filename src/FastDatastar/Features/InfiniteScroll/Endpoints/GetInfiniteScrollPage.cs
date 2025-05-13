using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Features.InfiniteScroll.Endpoints;

public class GetInfiniteScrollPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/infinite-scroll");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/InfiniteScroll", new { }).ExecuteAsync(this.HttpContext);
    }
}