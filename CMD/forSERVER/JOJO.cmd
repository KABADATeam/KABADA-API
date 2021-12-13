set HOJO=%~dp0
call DOWN.cmd

timeout 20

cd "%HOJO%"
call UP.cmd
