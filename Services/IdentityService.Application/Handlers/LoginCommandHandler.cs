using CQRS;
using IdentityService.Application.Commands;

namespace IdentityService.Application.Handlers;

public class LoginCommandHandler
    : ICommandHandler<LoginCommand, LoginResult>
{
    public async Task<LoginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var login = command.Login;
        
        Console.WriteLine($"Autenticando usuário: {login.Username}");
        
        return new LoginResult(true);
    }
}