#!/bin/sh
echo "Executing MSBuild DLL begin command..."
dotnet ./tools/sonar/SonarScanner.MSBuild.dll begin /o:"gmike" /k:"RomanSoloweow_WordsToNumber" /d:sonar.cs.vstest.reportsPaths="../TestResults/TestResult.trx" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.verbose=true /d:sonar.visualstudio.enable=true /d:sonar.login=${SONAR_TOKEN}
echo "Running build..."
dotnet build WordsToNumber.sln
echo "Running tests..."
dotnet test WordsToNumber.sln --collect "Code Coverage" --logger trx
echo "Executing MSBuild DLL end command..."
dotnet ./tools/sonar/SonarScanner.MSBuild.dll end /d:sonar.login=${SONAR_TOKEN}
