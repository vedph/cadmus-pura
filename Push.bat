@echo off
echo PUSH PACKAGES TO NUGET
prompt
set nu=C:\Exe\nuget.exe
set src=-Source https://api.nuget.org/v3/index.json

%nu% push .\Cadmus.Pura.Parts\bin\Debug\*.nupkg %src%
%nu% push .\Cadmus.Pura.Services\bin\Debug\*.nupkg %src%
%nu% push .\Cadmus.Seed.Pura.Parts\bin\Debug\*.nupkg %src%
echo COMPLETED
pause
echo on
