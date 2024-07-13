== Ausgangslage:

Ich wollte eine Migration erstellen:

dotnet ef migrations add fistmigration --project .\CustomerService\CustomerService.csproj --startup-project .\CustomerWeb\CustomerWeb.csproj

== Problem:

Unable to create a 'DbContext' of type ''. 
The exception 'Unable to resolve service for type 'Microsoft.EntityFrameworkCore.DbContextOptions`1[CustomerService.EF.MyDBContext]' 
while attempting to activate 'CustomerService.EF.MyDBContext'.' 
was thrown while attempting to create an instance. 
For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728

== Ursache: 

das fehlte: im WebApi:
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.5" />
