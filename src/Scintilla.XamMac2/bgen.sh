#!/bin/zsh

# use this script to update the generated bindings from the api definition

dotnet build /t:bgen
git add -f generated/**/*.cs
rm generated/temp.*
