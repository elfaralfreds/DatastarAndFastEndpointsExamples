using FastDatastar.Helpers;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarFederation.Datastar.DependencyInjection;

namespace FastDatastar.Features.Site.Endpoints;

public class Get404Page : EndpointWithoutRequest
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("{*path:regex(^((?!\\.).)*$)}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var path = Route<string>("path");
        await SendStringAsync(
            await Results.Extensions.ViewAsString(
                this.HttpContext.Duplicate(), 
                "Errors/404", 
                new { Path = path }
            ),
            contentType: "text/html",
            statusCode: StatusCodes.Status404NotFound
        );
    }
}
