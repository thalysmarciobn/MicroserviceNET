using Common.CQRS;
using IdentityService.Application.Commands;
using IdentityService.Application.Responses;
using IdentityService.Domain.Interfaces;

namespace IdentityService.Application.Handlers;

public class RegisterCommandHandler(IUserRepository userRepository) : ICommandHandler<RegisterCommand, RegisterResponse>
{
    public async Task<RegisterResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var isCreated = await userRepository.InsertUserAsync(command.Username, command.Password);
        
        return new RegisterResponse(isCreated);
    }
}