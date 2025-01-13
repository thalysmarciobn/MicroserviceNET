using Carter;
using Common.CQRS;
using FluentValidation;
using IdentityService.Application.Commands;
using IdentityService.Application.Requests;
using IdentityService.Application.Responses;
using Mapster;

namespace IdentityService.API.Endpoints.Login;

public class LoginEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/login",
                async (LoginRequest request, IValidator<LoginCommand> validator,
                    ICommandHandler<LoginCommand, LoginResponse> handler) =>
                {
                    var command = request.Adapt<LoginCommand>();
                    
                    var validationResult = await validator.ValidateAsync(command);

                    if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

                    var result = await handler.Handle(command, CancellationToken.None);

                    return Results.Ok(result);
                }).WithName("Login")
            .Produces<LoginResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}