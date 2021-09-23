cd "%~dp0"
cd ..
cd "KabadaAPI"
dotnet ef database drop --force
dotnet ef database update
