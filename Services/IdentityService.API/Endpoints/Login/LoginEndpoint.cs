using Carter;
using Common.CQRS;
using FluentValidation;
using IdentityService.Application.Commands;
using IdentityService.Application.Responses;

namespace IdentityService.API.Endpoints.Login;

public class LoginEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/login",
                async (LoginCommand request, IValidator<LoginCommand> validator,
                    ICommandHandler<LoginCommand, LoginResponse> handler) =>
                {
                    var validationResult = await validator.ValidateAsync(request);

                    if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

                    var result = await handler.Handle(request, CancellationToken.None);

                    return Results.Ok(result);
                }).WithName("Login")
            .Produces<LoginResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}