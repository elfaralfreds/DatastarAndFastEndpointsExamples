
using FastEndpoints;

public class GetFileUploadPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/file-upload");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/FileUpload", new { }).ExecuteAsync(this.HttpContext);
    }
}