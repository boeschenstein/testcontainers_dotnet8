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

        //services.AddTransient<IDbConnectionProvider>(provider => new DbConnectionProvider("Host=127.0.0.1;Port=8080;Database=postgres;Username=postgres;Password=postgres"));
        //services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //services.AddTransient<IGenericRepository<Customer>, GenericRepository<Customer>>();
        services.AddTransient<ICustomerService, Customers.CustomerService>();
    }
}