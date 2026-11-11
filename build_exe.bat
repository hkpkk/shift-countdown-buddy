@echo off
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:winexe /out:"%~dp0ShiftBuddy.exe" "%~dp0src\ShiftBuddy.cs"
if exist "%~dp0ShiftBuddy.exe" (
    start "" "%~dp0ShiftBuddy.exe"
)

