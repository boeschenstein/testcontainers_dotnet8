using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

//using Microsoft.VisualStudio.TestPlatform.TestHost;

using Testcontainers.PostgreSql;

namespace CustomerService.Tests;

// benötigit Microsoft.AspNetCore.Mvc.Testing
public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithImage("postgres:16.2")
        .WithDatabase("umgDb")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            //services.AddMarten(ConnectionString).UseLightweightSessions();
        });

        builder.UseEnvironment("IntegrationTests");
    }

    //public string ConnectionString => _dbContainer.GetConnectionString();

    public Task InitializeAsync() => _dbContainer.StartAsync();

    public new Task DisposeAsync() => _dbContainer.DisposeAsync().AsTask();
}