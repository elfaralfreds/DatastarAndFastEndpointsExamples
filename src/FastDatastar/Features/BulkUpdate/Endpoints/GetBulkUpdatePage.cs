
using FastEndpoints;

public class GetBulkUpdatePage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/bulk-update");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/BulkUpdate", new { }).ExecuteAsync(this.HttpContext);
    }
}