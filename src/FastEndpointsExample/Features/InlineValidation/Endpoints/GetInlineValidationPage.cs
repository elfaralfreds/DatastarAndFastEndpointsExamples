
using FastEndpoints;

public class GetInlineValidationPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/inline-validation");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/InlineValidation", new { }).ExecuteAsync(this.HttpContext);
    }
}