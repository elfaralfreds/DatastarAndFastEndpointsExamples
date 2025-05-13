using FastDatastar.Helpers;
using FastDatastar.Features.ClickToEdit.Services;
using FastEndpoints;

namespace FastDatastar.Features.ClickToEdit.Endpoints;

public class GetClickToEditPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/click-to-edit");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View(
                "Sites/Examples/ClickToEdit",
                new
                {
                    User = UserService.CurrentUser
                }
            ).ExecuteAsync(this.HttpContext);
    }
}