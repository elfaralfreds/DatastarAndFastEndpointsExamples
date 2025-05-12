
using FastEndpoints;

public class GetClickToEditPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/click-to-edit");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/ClickToEdit", new { }).ExecuteAsync(this.HttpContext);
    }
}