
using FastEndpoints;
using FastEndpointsExample.Helpers;
using StarFederation.Datastar.DependencyInjection;

public class EditContact : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/click-to-edit/edit-contact");
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
            User = new
            {
                Firstname = "John",
                Lastname = "Doe",
                Email = "joe@blow.com"
            }
        };

        await sse.MergeFragmentsAsync(
            await Results.Extensions.ViewAsString(this.HttpContext.Duplicate(), "_Partials/ClickToEditForm", payload)
        );
    }
}