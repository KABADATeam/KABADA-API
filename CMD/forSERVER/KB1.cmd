@echo on
REM    PREREQUISITES
REM 
cd "%~dp0"
set A=kabada-api
set C=%A%-master
set B=%C%.zip
IF NOT EXIST "%B%" (
  echo ABORT: missing file '%B%'.
  goto :eof
)
set V=kabada-web
set U=%V%-master
set W=%U%.zip
IF NOT EXIST "%W%" (
  echo ABORT: missing file '%W%'.
  goto :eof
)

set SAVESTAMP=%DATE:/=-%@%TIME::=-%
set SAVESTAMP=%SAVESTAMP: =%
set STAMP=%SAVESTAMP%

if exist %A%\ (
  move %A% %A%%STAMP%
)

if exist %V%\ (
  move %V% %V%%STAMP%
)
call unzip0.cmd %B%
ren %C% %A%

call unzip0.cmd %W%
ren %U% %V%

del /f /q "%A%\KabadaAPI\Properties\launchSettings.json"

goto :eof
