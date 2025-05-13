using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Features.Sortable.Endpoints;

public class GetSortablePage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/sortable");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/Sortable", new { }).ExecuteAsync(this.HttpContext);
    }
}