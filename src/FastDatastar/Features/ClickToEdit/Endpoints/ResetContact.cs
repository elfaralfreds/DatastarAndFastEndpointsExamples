
using FastEndpoints;
using FastEndpointsExample.Helpers;
using StarFederation.Datastar.DependencyInjection;

public class ResetContact : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/click-to-edit/reset-contact");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        IDatastarServerSentEventService? sse = TryResolve<IDatastarServerSentEventService>();
        if (sse == null)
        {
            await SendAsync("Server-Sent Events not available", 500);
            return;
        }

        UserService.CurrentUser = UserService.ResetUser();
        UserService.CurrentUser.Lastname = "Reset";
        var payload = new
        {
            User = UserService.CurrentUser
        };

        await sse.MergeFragmentsAsync(
            await Results.Extensions.ViewAsString(this.HttpContext.Duplicate(), "_Partials/ClickToEditDisplay", payload)
        );
    }
}