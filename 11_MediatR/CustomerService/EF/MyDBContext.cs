using Microsoft.EntityFrameworkCore;

namespace CustomerService.EF;

public class MyDBContext : DbContext, IUnitOfWork
{
    //private readonly string connectionString;

    public DbSet<Customers.Customer> Customers { get; set; }

    public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
    {
        // dieser ctr ist von services.AddDbContext verlangt
    }

    //public MyDBContext(string connectionString)
    //{
    //    // dieser Constructur wird bei den Integrationstests verwendet

    //    this.connectionString = connectionString;
    //    // dieser ctr ist von services.AddDbContext verlangt
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");

    // kompiliert, aber wenn das da ist, läuft die app nicht
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseNpgsql(this.connectionString);

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseNpgsql(configurationManager.GetConnectionString("MyDBContext"));
}