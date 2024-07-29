# Testcontainers .NET 8 (PostgreSQL)

## Add Hangfire (PostgreSQL)

<https://pradeepradyumna.medium.com/your-first-hangfire-job-for-net8-with-postgresql-22a0a3935b55>

Nugets

```cmd
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Hangfire.AspNetCore
dotnet add package Hangfire.PostgreSql
```

Services:

```cs
builder.Services.AddHangfire(x => x.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("defaultConnection")));
```

Middleware:

```cs
app.UseHangfireDashboard("/dashboard");
app.UseHangfireServer();
```

## todo

- do the same using Aspire


