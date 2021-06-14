cd "%~dp0"
cd ..
del "KabadaAPI.DataSource\Migrations\*"

dotnet build

cd "KabadaAPI.DataSource"
dotnet ef migrations add InitialCreate -s ..\KabadaAPI\KabadaAPI.csproj
dotnet ef database drop --force -s ..\KabadaAPI\KabadaAPI.csproj
dotnet ef database update -s ..\KabadaAPI\KabadaAPI.csproj
