#!/usr/bin/env bash


echo "Start Console"
INPUT_PATH=$(pwd)/$1
cd Console
dotnet restore
dotnet build --configuration Release --no-restore
cd TravelRouteConsole
dotnet run $INPUT_PATH