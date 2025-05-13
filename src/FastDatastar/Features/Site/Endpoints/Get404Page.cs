// using FastEndpoints;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using StarFederation.Datastar.DependencyInjection;

// namespace FastDatastar.Features.Site.Endpoints;

// public class Get404Page : EndpointWithoutRequest
// {
//     public override void Configure()
//     {
//         Verbs(Http.GET);
//         Routes("{*path:regex(^((?!\\.).)*$)}");
//         AllowAnonymous();                // no auth required
//         // Summary(s => s.WithTags("Errors"));
//     }

//     public override async Task HandleAsync(CancellationToken ct)
//     {
//         var path = Route<string>("path");
//         await Results.Extensions.View("Errors/404", new { Path = path }).ExecuteAsync(this.HttpContext);
//     }
// }
