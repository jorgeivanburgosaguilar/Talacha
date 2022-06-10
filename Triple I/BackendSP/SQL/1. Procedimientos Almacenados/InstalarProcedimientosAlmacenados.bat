@echo off
REM Este script sirve para instalar todos los archivo *.sql (codificados bajo UTF-8) del directorio
REM y subdirectorios actuales desde donde se corre el script excluyendo el script de sql compare.
setlocal
cd .
for /r %%f in (*.sql) do call :ejecutarsql "%%f"
GOTO FIN

:ejecutarsql
IF %ERRORLEVEL% NEQ 0 GOTO ERROR
IF "%~1" == "%~dp0SQL Compare Script.sql" GOTO :EOF
echo %1
sqlcmd -f 65001 -b -E -S lpc:.\ -i %1
GOTO :EOF

:ERROR
echo Error
GOTO :EOF

:FIN
pause
GOTO :EOF