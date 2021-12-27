SET p=kabada-api
call :function_name 
SET p=kabada-web
call :function_name 
EXIT /B 0

:function_name 
cd "%~dp0"
cd %p%
git pull
cd ..
set n=%p%-master.zip

del %n%
"C:\Users\kabada\test\PAPS\PortableApps\7-ZipPortable\App\7-Zip\7z" a  %n% %p% -r

EXIT /B 0