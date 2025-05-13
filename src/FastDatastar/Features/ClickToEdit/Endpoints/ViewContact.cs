
using FastEndpoints;
using FastEndpointsExample.Helpers;
using StarFederation.Datastar.DependencyInjection;

public class ViewContact : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/click-to-edit/view-contact");
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

        var payload = new
        {
            User = UserService.CurrentUser
        };

        await sse.MergeFragmentsAsync(
            await Results.Extensions.ViewAsString(this.HttpContext.Duplicate(), "_Partials/ClickToEditDisplay", payload)
        );
    }
}