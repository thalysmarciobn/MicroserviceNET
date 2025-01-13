using Common.CQRS;
using IdentityService.Application.Commands;
using IdentityService.Application.Responses;

namespace IdentityService.Application.Handlers;

public class LoginCommandHandler
    : ICommandHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Autenticando usuário: {command.Username}");

        return new LoginResponse(true);
    }
}