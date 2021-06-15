@echo off
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

set CUR_YYYY=%date:~10,4%
set CUR_MM=%date:~4,2%
set CUR_DD=%date:~7,2%
set CUR_HH=%time:~0,2%
if %CUR_HH% lss 10 (set CUR_HH=0%time:~1,1%)
set CUR_NN=%time:~3,2%
set CUR_SS=%time:~6,2%
set CUR_MS=%time:~9,2%
set STAMP=%CUR_YYYY%%CUR_MM%%CUR_DD%-%CUR_HH%%CUR_NN%%CUR_SS%

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

goto :eof
