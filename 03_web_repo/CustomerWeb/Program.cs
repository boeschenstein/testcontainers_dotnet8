using Customers;

using CustomerService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// run this first:
// docker run -p 8080:5432 -e POSTGRES_PASSWORD=postgres postgres
builder.Services.AddTransient<IDbConnectionProvider>(provider => new DbConnectionProvider("Host=127.0.0.1;Port=8080;Database=postgres;Username=postgres;Password=postgres"));
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerService, Customers.CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();