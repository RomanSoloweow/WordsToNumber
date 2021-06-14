#!/bin/sh
echo "Starting install..."
wget -O sonar.zip https://github.com/SonarSource/sonar-scanner-msbuild/releases/download/5.2.1/sonar-scanner-msbuild-5.2.1.31210-netcoreapp3.0.zip
echo "Unzipping..."
unzip -qq sonar.zip -d tools/sonar
echo "Displaying file structure..."
find .
ls -l tools/sonar
echo "Changing permissions..."
