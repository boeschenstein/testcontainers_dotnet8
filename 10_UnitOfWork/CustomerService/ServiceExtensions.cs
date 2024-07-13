using Customers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService;

public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services, IConfigurationManager configurationManager)
    {
        services.AddDbContext<CustomerService.EF.MyDBContext>(options =>
                options.UseNpgsql(configurationManager.GetConnectionString("MyDBContext")));

        _ = services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CustomerService.EF.MyDBContext>());

        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<ICustomerService, Customers.CustomerService>();
    }
}