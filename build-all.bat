@echo off
dotnet test Tests -c Release
dotnet build ReadMeGenerator -c Release
dotnet run ReadMeGenerator\bin\Release\netcoreapp1.0\ReadMeGenerator.dll
dotnet pack [Main] -c Release