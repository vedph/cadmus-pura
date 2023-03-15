@echo off
echo PRESS ANY KEY TO INSTALL TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.Pura.Parts\bin\Debug\Cadmus.Pura.Parts.5.0.4.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Pura.Services\bin\Debug\Cadmus.Pura.Services.5.0.4.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.Pura.Parts\bin\Debug\Cadmus.Seed.Pura.Parts.5.0.4.nupkg -source C:\Projects\_NuGet
pause
