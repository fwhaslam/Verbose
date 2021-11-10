REM 
REM this file needs to 'save as' US-ASCII so it will function, default of UTF-8 will make it un-runnnable.
REM
REM NOTE: this is part of the Test project for two reasons:
REM       1) this guarantees that the nuget package has been created
REM       2) this guarantees that tests have paassed
REM 
echo     Trying to deploy nuget package to repository.

set VERSION=%1
set PROJECT=%2
rem echo VERSION=[%VERSION%]
rem echo PROJECT=[%PROJECT%]

rem DEVELOPER SPECIFIC VALUE
set REPO=C:\Users\Fred\NugetRepository


@echo off
For /f "tokens=2-4 delims=/ " %%a in ('echo %DATE%') do (set mydate=%%c%%a%%b)
For /f "tokens=1-4 delims=:." %%a in ('echo %TIME%') do (set mytime=%%a%%b%%c%%d)
set TIMESTAMP=%mydate%%mytime%
echo TIMESTAMP=[%TIMESTAMP%]

rem set FILE=..\Verbose\bin\Release\Verbose.0.0.1-alpha.nupkg
set FILE=..\%PROJECT%\bin\Release\%PROJECT%.%VERSION%.nupkg
set FILESTAMPED=..\%PROJECT%\bin\Release\%PROJECT%.%VERSION%%TIMESTAMP%.nupkg
copy %FILE% %FILESTAMPED%

echo CMD [nuget add %FILESTAMPED% -source %REPO%]
nuget add %FILESTAMPED% -source %REPO%

