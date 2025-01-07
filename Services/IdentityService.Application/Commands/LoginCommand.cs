using CQRS;
using IdentityService.Application.Requests;

namespace IdentityService.Application.Commands;

public record LoginResult(bool IsSuccess);

public record LoginCommand(LoginRequest Login) 
    : ICommand<LoginResult>;