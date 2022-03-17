using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volvo.EntityFramework.Context;
using Xunit;

namespace Volvo.EntityFramework.Test;

public abstract class BaseTest
{
    public BaseTest()
    {

    }

    
}

public class DbTest : IDisposable
{
    private string databaseName = $"volvo_test_{Guid.NewGuid().ToString().Replace("-",string.Empty)}";
    public ServiceProvider ServiceProvider { get; private set; }

    public DbTest()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<MyContext>(options =>
        options.UseMySql($"server=localhost; database={databaseName}; user=diego; password=PHCfoco2019;",new MySqlServerVersion(new Version(8, 0, 28))),
            ServiceLifetime.Transient
        );

        ServiceProvider = serviceCollection.BuildServiceProvider();
        using (var context = ServiceProvider.GetService<MyContext>())
        {
            context.Database.EnsureCreated();
        }
    }

    public void Dispose()
    {
        using (var context = ServiceProvider.GetService<MyContext>())
        {
            context.Database.EnsureDeleted();
        }
    }
}