using Common.CQRS;
using IdentityService.Application.Commands;
using IdentityService.Application.Responses;
using IdentityService.Domain.Interfaces;

namespace IdentityService.Application.Handlers;

public class LoginCommandHandler(IUserRepository? userRepository) : ICommandHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByCredentialsAsync(command.Username, command.Password);
        
        return new LoginResponse(user != null);
    }
}