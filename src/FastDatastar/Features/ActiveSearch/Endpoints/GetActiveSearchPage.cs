using FastDatastar.Features.ActiveSearch.Dto;
using FastDatastar.Features.ActiveSearch.Services;
using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Features.ActiveSearch.Endpoints;

public class GetActiveSearchPage : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/active-search");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var input = string.Empty;

        var payload = new
        {
            Input = input,
            Contacts = ContactService.Search(input),
            Total = ContactService.Contacts.Count
        };

        await SendStringAsync(
            await Results.Extensions.ViewAsString(
                this.HttpContext.Duplicate(), "Sites/Examples/ActiveSearch", 
                payload
            ),
            contentType: "text/html"
        );
    }
}