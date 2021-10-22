@ECHO OFF

set currentPath=%cd%
set cdCurrentPath=cd %currentPath%
set drive=%cd:~0,2%
set bartender=%cdCurrentPath%
set compile=csc *.cs -r:System.Windows.Forms.dll
set run=main.exe
c:
cd C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Mono
echo ________________________________________________________
echo  The mono environment started if everything went fine. 
echo       Now to compile and run the app just write
echo      "%%drive%% & %%bartender%% & %%compile%% & %%run%%"
echo   into the command line without the quotation marks. 
echo          You can also copy it from here.
echo ________________________________________________________
"Open Mono x64 Command Prompt.lnk"
pause
