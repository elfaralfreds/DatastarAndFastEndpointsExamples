
using FastEndpoints;

public class GetActiveSearchPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/active-search");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/ActiveSearch", new { }).ExecuteAsync(this.HttpContext);
    }
}