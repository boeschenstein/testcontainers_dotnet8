using Testcontainers.PostgreSql;

namespace Customers.Tests;

public sealed class CustomerServiceTest : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
        //.WithImage("postgres:15-alpine")
        .WithImage("postgres:16.2")
        .Build();

    public Task InitializeAsync()
    {
        return _postgres.StartAsync();
    }

    public Task DisposeAsync()
    {
        return _postgres.DisposeAsync().AsTask();
    }

    [Fact]
    public void ShouldReturnTwoCustomers()
    {
        // Given
        var repo = new CustomerRepository(new DbConnectionProvider(_postgres.GetConnectionString()));
        var customerService = new CustomerService(repo);

        // When
        customerService.Create(new Customer(1, "George"));
        customerService.Create(new Customer(2, "John"));
        customerService.Create(new Customer(3, "Susi"));
        var customers = customerService.GetCustomers();

        // Then
        Assert.Equal(3, customers.Count());
    }
}