using IdentityService.Application.Commands;
using IdentityService.Application.Handlers;

namespace IdentityService.Test;

[TestClass]
public sealed class LoginCommandHandlerTests
{
    private LoginCommandHandler? _handler;
    
    [TestInitialize]
    public void Setup()
    {
        _handler = new LoginCommandHandler();
    }
    
    [TestMethod]
    public async Task Handle_ValidCredentials_ReturnsSuccessResponse()
    {
        var command = new LoginCommand("testuser", "testpassword" );
        
        var result = await _handler!.Handle(command, CancellationToken.None);
        
        Assert.IsTrue(result.IsSuccess);
    }
}