
using System.Text.Json;
using FastDatastar.Features.ClickToEdit.Dto;
using FastDatastar.Features.ClickToEdit.Services;
using FastDatastar.Features.ClickToEdit.Validators;
using FastEndpoints;
using FastDatastar.Helpers;
using StarFederation.Datastar.DependencyInjection;

namespace FastDatastar.Features.ClickToEdit.Endpoints;

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

        request.Firstname = HtmlSanitizer.Sanitize(request.Firstname);
        request.Lastname = HtmlSanitizer.Sanitize(request.Lastname);
        request.Email = HtmlSanitizer.Sanitize(request.Email);

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