using FastEndpoints;
using FastDatastar.Helpers;
using StarFederation.Datastar.DependencyInjection;
using FastDatastar.Features.ActiveSearch.Services;

namespace FastDatastar.Features.ActiveSearch.Endpoints;

public class GetContacts : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/active-search/get-contacts");
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

        var request = await dsSignals.ReadSignalsAsync<Search>();
        request.Input = HtmlSanitizer.Sanitize(request.Input);

        Console.WriteLine($"Received request: {request.Input}");

        var payload = new
        {
            Input = request.Input,
            Contacts = ContactService.Search(request.Input),
            Total = ContactService.Contacts.Count
        };

        await sse.MergeFragmentsAsync(
            await Results.Extensions.ViewAsString(
                this.HttpContext.Duplicate(), 
                "_Partials/ActiveSearchDisplay",
                payload
            )
        );
    }
}