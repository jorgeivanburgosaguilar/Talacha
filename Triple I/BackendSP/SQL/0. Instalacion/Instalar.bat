@echo off
REM Este script sirve para instalar todos los archivo .sql (codificados bajo UTF-8) del directorio desde donde se corre
setlocal
cd .
for %%f in (*.sql) do call :ejecutarsql "%~dp0%%f"
GOTO FIN

:ejecutarsql
IF %ERRORLEVEL% NEQ 0 GOTO ERROR
echo %1
sqlcmd -f 65001 -b -E -S lpc:.\ -i %1
GOTO :EOF

:ERROR
echo Error
GOTO :EOF

:FIN
pause
GOTO :EOF