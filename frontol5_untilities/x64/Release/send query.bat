@echo off
chcp 1251
cls
color 8e
echo ѕроизводитс€ запуск следующих сервисов дл€ работы с Frontol:
echo.
net start FirebirdServerDefaultInstance
net start srvFrontol
net start fdsvc
echo.
echo ѕопытки запуска необходимых сервисов завершены.
echo.
echo ѕроисходит выполнение запроса (-ов)...
echo.
set isql="%PROGRAMFILES(x86)%\FireBird\FireBird_2_1\BIN\isql.exe"
set inputfile="%~dp0query.sql"
set outputfile="%~dp0output.txt"
%isql% -i %inputfile% -o %outputfile% -q
echo ѕопытка (-ки) выполнени€ запроса (-ов) были завершены.
echo.
pause