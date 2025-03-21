using IdentityService.Application;
using IdentityService.Application.Commands;
using IdentityService.Application.Handlers;
using IdentityService.Domain.Interfaces;
using IdentityService.Infrastructure.Data;
using IdentityService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Test;

[TestClass]
public sealed class LoginCommandHandlerTests
{
    private IServiceProvider? serviceProvider { get; set; }
    
    [TestInitialize]
    public void Setup()
    {
        var serviceCollection = new ServiceCollection();
        
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("TestDatabase"));
        
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        
        serviceProvider = serviceCollection.BuildServiceProvider();
    }
    
    [TestMethod]
    public async Task Register()
    {
        var handler = new RegisterCommandHandler(serviceProvider.GetService<IUserRepository>());
        
        var command = new RegisterCommand("string", "string" );
        
        var result = await handler!.Handle(command, CancellationToken.None);
        
        Assert.IsTrue(result.IsSuccess);
    }
}