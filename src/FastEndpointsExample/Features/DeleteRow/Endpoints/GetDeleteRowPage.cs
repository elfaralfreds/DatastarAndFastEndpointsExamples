
using FastEndpoints;

public class GetDeleteRowPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/delete-row");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/DeleteRow", new { }).ExecuteAsync(this.HttpContext);
    }
}