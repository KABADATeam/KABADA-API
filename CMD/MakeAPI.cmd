cd "%~dp0"
cd ..
dotnet build
cd "KabadaAPI"
dotnet ef database drop --force
dotnet ef database update
