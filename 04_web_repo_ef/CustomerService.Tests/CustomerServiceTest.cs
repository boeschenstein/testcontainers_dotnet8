using CustomerService;
using CustomerService.EF;

using Testcontainers.PostgreSql;

namespace Customers.Tests;

public sealed class CustomerServiceTest //: IAsyncLifetime
{
    public CustomerServiceTest()
    {
    }

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
        //var repo = new CustomerRepository(new DbConnectionProvider(_postgres.GetConnectionString()));
        // todo !!!
        var repo = new CustomerRepository(new MyDBContext(null));
        var customerService = new CustomerService(repo);

        // When
        customerService.Create(new Customer { Id = 1, Name = "George" });
        customerService.Create(new Customer { Id = 2, Name = "John" });
        customerService.Create(new Customer { Id = 3, Name = "Susi" });
        var customers = customerService.GetCustomers();

        // Then
        Assert.Equal(3, customers.Count());
    }
}