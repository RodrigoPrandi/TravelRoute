#!/usr/bin/env bash

DIR=$(pwd)

echo "Tests Console"
cd Console
dotnet restore
dotnet build --configuration Release --no-restore
dotnet test --no-restore --verbosity normal

cd $DIR

echo "Tests API"
cd Api
dotnet restore
dotnet build --configuration Release --no-restore
dotnet test --no-restore --verbosity normal