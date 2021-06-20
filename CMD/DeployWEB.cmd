cd "%~dp0"

cd ..
RD /S /Q ".\KabadaAPI\wwwroot\"

xcopy /E "..\kabada-web\build\*.*" ".\KabadaAPI\wwwroot\"
