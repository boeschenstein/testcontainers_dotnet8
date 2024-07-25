using CustomerService;
using CustomerService.EF;

using Hangfire;
using Hangfire.PostgreSql;

using Microsoft.EntityFrameworkCore;

//namespace CustomerWeb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// !!!!!!!!!!!!!!!
// run this first:
// !!!!!!!!!!!!!!!
// docker run -p 8080:5432 -e POSTGRES_PASSWORD=postgres postgres
// see run_posgres_in_docker.cmd
// !!!!!!!!!!!!!!!

builder.Services.ConfigureServices(builder.Configuration);

builder.Services.AddHangfire(x =>
    x.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("MyDBContext")));

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

// https://pradeepradyumna.medium.com/your-first-hangfire-job-for-net8-with-postgresql-22a0a3935b55
app.UseHangfireDashboard("/dashboard");
app.UseHangfireServer();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyDBContext>();
    // run migrations
    db.Database.Migrate();
}

app.Run();

// Make the implicit Program class public so test projects can access it
// tbv: alternatively, you can make it public to the test using the [assembly: InternalsVisibleTo("TestProject")] attribute
// or xml attribute in the csproj file: InternalsVisibleTo include="TestProject"
public partial class Program
{
    protected Program()
    { }
}