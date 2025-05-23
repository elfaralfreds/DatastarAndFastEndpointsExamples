using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Features.ProgressBar.Endpoints;

public class GetProgressBarPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/progressbar");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/ProgressBar", new { }).ExecuteAsync(this.HttpContext);
    }
}