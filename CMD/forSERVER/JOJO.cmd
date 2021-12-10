set H=%~dp0
call DOWN.cmd

timeout 20

cd "%H%"
call UP.cmd
