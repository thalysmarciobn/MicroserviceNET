using Common.CQRS;
using IdentityService.Application.Requests;
using IdentityService.Application.Responses;

namespace IdentityService.Application.Commands;

public record LoginCommand(LoginRequest Login)
    : ICommand<LoginResponse>;