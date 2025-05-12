
using FastEndpoints;

public class GetExamplesPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/Default", new { }).ExecuteAsync(this.HttpContext);
    }
}