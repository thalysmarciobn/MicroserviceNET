using Common.CQRS;
using IdentityService.Application.Responses;

namespace IdentityService.Application.Commands;

public record LoginCommand(string Username,
    string Password) : ICommand<LoginResponse>;
