
using FastEndpoints;

public class ResetContact : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/click-to-edit/reset-contact");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View(
                "_Partials/ClickToEditForm",
                new
                {
                    User = new 
                    {
                        Firstname = "John",
                        Lastname = "Doe",
                        Email = "joe@blow.com"
                    }
                }
            ).ExecuteAsync(this.HttpContext);
    }
}