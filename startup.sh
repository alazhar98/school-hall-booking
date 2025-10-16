#!/bin/bash

# Create App_Data directory if it doesn't exist
mkdir -p /home/site/wwwroot/App_Data

# Set proper permissions
chmod 755 /home/site/wwwroot/App_Data

# Run the application
dotnet SchoolHallBooking.dll
