using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Features.EditRow.Endpoints;

public class GetEditRowPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/edit-row");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/EditRow", new { }).ExecuteAsync(this.HttpContext);
    }
}