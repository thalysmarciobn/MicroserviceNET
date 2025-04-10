using IdentityService.Application.Commands;
using IdentityService.Application.Handlers;
using IdentityService.Domain.Interfaces;
using IdentityService.Infrastructure.Data;
using IdentityService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Test;

[TestClass]
public sealed class AuthCommandHandlerTests
{
    private static IServiceProvider? _serviceProvider;
    private static DbContextOptions<ApplicationDbContext>? _dbContextOptions;

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        var services = new ServiceCollection();

        services.AddScoped(_ => new ApplicationDbContext(_dbContextOptions!));
        services.AddScoped<IUserRepository, UserRepository>();

        _serviceProvider = services.BuildServiceProvider();
    }

    [TestMethod]
    public async Task RegisterShouldSucceed()
    {
        using var scope = _serviceProvider!.CreateScope();

        var handler = new RegisterCommandHandler(scope.ServiceProvider.GetRequiredService<IUserRepository>());
        var command = new RegisterCommand("string", "string");

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.IsTrue(result.IsSuccess);
    }

    [TestMethod]
    public async Task LoginShouldSucceed()
    {
        await RegisterShouldSucceed();

        using var scope = _serviceProvider!.CreateScope();

        var handler = new LoginCommandHandler(scope.ServiceProvider.GetRequiredService<IUserRepository>());
        var command = new LoginCommand("string", "string");

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.IsTrue(result.IsSuccess);
    }
}
