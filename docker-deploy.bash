#!/bin/bash

set -e

NUGET_PUSH_SOURCE="https://api.nuget.org/v3/index.json"
NUGET_PACKAGE_FILENAME=/app/publish/$NUGET_PROJECT_NAME.*.nupkg
#NUGET_PROJECT_NAME - export from environment
#NUGET_APIKEY - export from environment

if [[ -z $NUGET_PUSH_SOURCE ]]; then
  echo "=== No NUGET_PUSH_SOURCE specified, aborting."
  exit 1
fi

if [[ -z $NUGET_APIKEY ]]; then
  echo "=== No NUGET_APIKEY specified, aborting."
  exit 1
fi

if [[ -f $NUGET_PACKAGE_FILENAME ]]; then
  echo "Pushing $NUGET_PACKAGE_FILENAME to $NUGET_PUSH_SOURCE"
  dotnet nuget push $NUGET_PACKAGE_FILENAME --source $NUGET_PUSH_SOURCE --api-key $NUGET_APIKEY
else
  echo "=== Cannot find $NUGET_PACKAGE_FILENAME - aborting."
  exit 1
fi
