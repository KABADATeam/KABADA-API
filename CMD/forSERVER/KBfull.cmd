set H=%~dp0

echo SNP unload old DB contentents and stop servers
call SNP.cmd

echo %H%
echo KB1 prepare application directories
call KB1.cmd

cd "%H%"
echo KB2 perform application build
call KB2.cmd

cd "%H%"
echo KB3 start application
call KB3.cmd
