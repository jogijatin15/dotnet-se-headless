#!/usr/bin/env bash
set -e -x

export DISPLAY=:99
bash /etc/init.d/xvfb start

ls -las

echo "Starting nUnit Test Case Execution"

dotnet restore
dotnet test

echo "Finishing nUnit Test Case Execution"

ls -ltr
