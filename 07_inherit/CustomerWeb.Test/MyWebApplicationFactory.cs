using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CustomerWeb.Test;

internal class MyWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //builder.ConfigureServices(services =>
        //{
        //    var descriptor = services.SingleOrDefault(
        //        d => d.ServiceType ==
        //            typeof(DbContextOptions<CustomerWebContext>));

        //    services.Remove(descriptor);

        //    services.AddDbContext<CustomerWebContext>(options =>
        //    {
        //        options.UseInMemoryDatabase("InMemoryDbForTesting");
        //    });

        //    var sp = services.BuildServiceProvider();

        //    using var scope = sp.CreateScope();
        //    var scopedServices = scope.ServiceProvider;
        //    var db = scopedServices.GetRequiredService<CustomerWebContext>();

        //    db.Database.EnsureCreated();

        //    try
        //    {
        //        SeedData.PopulateTestData(db);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //});
    }

    public Task InitializeAsync()
    {
        throw new NotImplementedException();
    }

    Task IAsyncLifetime.DisposeAsync()
    {
        throw new NotImplementedException();
    }
}