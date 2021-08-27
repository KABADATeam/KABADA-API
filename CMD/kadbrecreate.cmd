cd "%~dp0"
cd ..
del "KabadaAPI\Migrations\*" /Q

dotnet build

cd "KabadaAPI"
dotnet ef migrations add InitialCreate 
dotnet ef database drop --force
dotnet ef database update
