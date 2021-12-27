SET s="%~dp0\CLEAN"
cd "%s%"
call makeCLEAN.cmd

cd "%~dp0"

SET p=kabada-api
call :function_name 
SET p=kabada-web
call :function_name
pause
EXIT /B 0

:function_name 
set n=%p%-master.zip

set SAVESTAMP=%DATE:/=-%@%TIME::=-%
set SAVESTAMP=%SAVESTAMP: =%
set SAVESTAMP=%SAVESTAMP%_%n%
echo %SAVESTAMP%
rename %n% %SAVESTAMP%

xcopy /y "%s%\%n%" .
EXIT /B 0