cd "%~dp0"
cd ..
RD /S /Q ".\KabadaAPI\wwroot\"
xcopy "..\kabada-web\build\*.*" ".\KabadaAPI\wwroot\"
