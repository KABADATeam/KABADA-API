cd "%~dp0"
cd ..
dotnet build
cd "KabadaAPI"
if "%KEEPOLD%"=="" dotnet ef database drop --force
dotnet ef database update
