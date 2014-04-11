echo off
cls

set BUILD_FOLDER=D:\DVT\vScreen.net\vScreen\bin\Debug
set TOOLS_FOLDER=C:\Tools
set VSCREEN_FOLDER=%TOOLS_FOLDER%\vScreen

if not exist "%TOOLS_FOLDER%" goto END

echo Copying vScreen.Net build to %VSCREEN_FOLDER%
if not exist "%VSCREEN_FOLDER%" md "%VSCREEN_FOLDER%"

copy "%BUILD_FOLDER%\*.*" "%VSCREEN_FOLDER%"

echo Done
pause

BUILD_FOLDER

:END

