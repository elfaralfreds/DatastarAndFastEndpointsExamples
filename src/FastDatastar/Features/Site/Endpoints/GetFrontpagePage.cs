
using FastEndpoints;

public class GetFrontpagePage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Frontpage", new { }).ExecuteAsync(this.HttpContext);
    }
}