# build
dotnet build -c Release
# publish library
Remove-Item -Path .\Cadmus.Pura.Services\bin\Release\net8.0\publish -Recurse -Force
dotnet publish .\Cadmus.Pura.Services\Cadmus.Pura.Services.csproj -c Release
# rename publish to Cadmus.Pura.Services and zip
Rename-Item -Path .\Cadmus.Pura.Services\bin\Release\net8.0\publish -NewName Cadmus.Pura.Services
compress-archive -path .\Cadmus.Pura.Services\bin\Release\net8.0\Cadmus.Pura.Services\ -DestinationPath .\Cadmus.Pura.Services\bin\Release\net8.0\Cadmus.Pura.Services.zip -Force
# rename back
Rename-Item -Path .\Cadmus.Pura.Services\bin\Release\net8.0\Cadmus.Pura.Services -NewName publish
