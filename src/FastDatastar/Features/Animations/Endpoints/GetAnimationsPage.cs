using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Features.Animations.Endpoints;

public class GetAnimationsPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/animations");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/Animations", new { }).ExecuteAsync(this.HttpContext);
    }
}