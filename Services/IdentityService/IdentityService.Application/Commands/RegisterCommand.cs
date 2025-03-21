using Common.CQRS;
using IdentityService.Application.Responses;

namespace IdentityService.Application.Commands;

public record RegisterCommand(string Username,
    string Password) : ICommand<RegisterResponse>;