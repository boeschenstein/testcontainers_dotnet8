using System.Net;

using CustomerService.Tests;

namespace Customers.Tests;

public sealed class CustomerServiceTest //: IAsyncLifetime
{
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