@echo off
chcp 1251
cls
color 8e
echo ������������ ������ ��������� �������� ��� ������ � Frontol:
echo.
net start FirebirdServerDefaultInstance
net start srvFrontol
net start fdsvc
echo.
echo ������� ������� ����������� �������� ���������.
echo.
echo ���������� ���������� ������� (-��)...
echo.
set isql="%PROGRAMFILES(x86)%\FireBird\FireBird_2_1\BIN\isql.exe"
set inputfile="%~dp0query.sql"
set outputfile="%~dp0output.txt"
%isql% -i %inputfile% -o %outputfile% -q
echo ������� (-��) ���������� ������� (-��) ���� ���������.
echo.
pause