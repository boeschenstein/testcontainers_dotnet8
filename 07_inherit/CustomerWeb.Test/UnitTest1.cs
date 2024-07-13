using System.Net;

namespace CustomerWeb.Test;

public class UnitTest1
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