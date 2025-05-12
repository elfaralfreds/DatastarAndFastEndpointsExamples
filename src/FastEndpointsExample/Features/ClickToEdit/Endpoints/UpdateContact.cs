
using System.Text.Json;
using FastEndpoints;
using FastEndpointsExample.Helpers;
using StarFederation.Datastar.DependencyInjection;

public class UpdateContact : EndpointWithoutRequest
{
    public override void Configure()
    {
        Put("/examples/click-to-edit/update-contact");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        IDatastarServerSentEventService? sse = TryResolve<IDatastarServerSentEventService>();
        IDatastarSignalsReaderService? dsSignals = TryResolve<IDatastarSignalsReaderService>();
        if (sse == null || dsSignals == null)
        {
            await SendAsync("Server-Sent Events not available", 500);
            return;
        }

        var request = await dsSignals.ReadSignalsAsync<User>();
        var userValidator = new UserValidator();
        var validation = await userValidator.ValidateAsync(request);

        if (!validation.IsValid)
        {
            Console.WriteLine("Validation failed");
            await sse.MergeFragmentsAsync(
                await Results.Extensions.ViewAsString(this.HttpContext.Duplicate(), "_Partials/ClickToEditForm", new
                {
                    User = request,
                    ValidationErrors = validation.Errors
                })
            );
            return;
        }
        
        Console.WriteLine("Validation succeeded");
        UserService.CurrentUser = request;

        await sse.MergeFragmentsAsync(
            await Results.Extensions.ViewAsString(this.HttpContext.Duplicate(), "_Partials/ClickToEditDisplay", new
            {
                User = UserService.CurrentUser
            })
        );
        
    }
}