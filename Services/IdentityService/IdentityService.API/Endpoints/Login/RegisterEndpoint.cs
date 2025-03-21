using Carter;
using Common.CQRS;
using FluentValidation;
using IdentityService.Application.Commands;
using IdentityService.Application.Requests;
using IdentityService.Application.Responses;
using Mapster;

namespace IdentityService.API.Endpoints.Login;

public class RegisterEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/register",
                async (LoginRequest request, IValidator<RegisterCommand> validator,
                    ICommandHandler<RegisterCommand, RegisterResponse> handler) =>
                {
                    var command = request.Adapt<RegisterCommand>();
                    
                    var validationResult = await validator.ValidateAsync(command);

                    if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

                    var result = await handler.Handle(command, CancellationToken.None);

                    return Results.Ok(result);
                }).WithName("Register")
            .Produces<RegisterResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}