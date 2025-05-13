using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Features.ValueSelect.Endpoints;

public class GetValueSelectPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/value-select");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/ValueSelect", new { }).ExecuteAsync(this.HttpContext);
    }
}