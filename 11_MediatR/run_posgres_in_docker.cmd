echo Install rancher desktop (similer to docker desktop, but free to use)
echo Run rancher desktop first

rem read .confg\dotnet-tools.json
dotnet tool restore

docker run -p 8080:5432 -e POSTGRES_PASSWORD=postgres postgres

pause
