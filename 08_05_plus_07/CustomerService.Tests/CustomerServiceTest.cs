using System.Net;

using CustomerService;
using CustomerService.EF;
using CustomerService.Tests;

namespace Customers.Tests;

public sealed class CustomerServiceTest //: IAsyncLifetime
{
    //public CustomerServiceTest()
    //{
    //}

    //private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
    //    //.WithImage("postgres:15-alpine")
    //    .WithImage("postgres:16.2")
    //    .Build();

    //public Task InitializeAsync()
    //{
    //    return _postgres.StartAsync();
    //}

    //public Task DisposeAsync()
    //{
    //    return _postgres.DisposeAsync().AsTask();
    //}

    [Fact(Skip = "skip this")]
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

    [Fact]
    public async Task Weatherforecast_ShouldReturnOk()
    {
        // to get access to Program, add a reference to the CustomerWeb project and <InternalsVisibleTo Include="CustomerWeb.Test"/> to csproj
        //var factory = new WebApplicationFactory<Program>();
        var factory = new MyWebApplicationFactory();
        var client = factory.CreateClient();
        var response = await client.GetAsync("/Weatherforecast");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}