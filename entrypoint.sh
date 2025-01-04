#!/bin/bash
set -e

# Run the migrations
echo "Applying migrations..."
dotnet ef database update --project /app/FridgeBE.Api/FridgeBE.Api.csproj

# Start the application
echo "Starting application..."
exec dotnet FridgeBE.Api.dll