rem works, but not needed:
rem db.Database.Migrate()
rem does the same in the app

dotnet ef database update --project .\CustomerService\CustomerService.csproj --startup-project .\CustomerWeb\CustomerWeb.csproj

pause
