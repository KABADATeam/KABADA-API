cd "%~dp0"
cd ..
dotnet build
cd "KabadaAPI.DataSource"
dotnet ef database drop --force -s ..\KabadaAPI\KabadaAPI.csproj"
dotnet ef database update -s ..\KabadaAPI\KabadaAPI.csproj
