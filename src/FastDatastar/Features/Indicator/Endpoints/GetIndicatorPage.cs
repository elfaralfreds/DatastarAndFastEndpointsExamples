using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Features.Indicator.Endpoints;

public class GetIndicatorPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/indicator");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/Indicator", new { }).ExecuteAsync(this.HttpContext);
    }
}