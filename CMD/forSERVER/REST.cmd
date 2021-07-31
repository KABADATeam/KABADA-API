set A=kabada-api

set H=%~dp0%A%\CMD

echo %H%

cd "%H%"
call RunPIU rest
