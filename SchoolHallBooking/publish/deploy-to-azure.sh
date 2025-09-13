#!/bin/bash

# Azure Deployment Script for School Hall Booking System
# Make sure to replace the placeholders with your actual values

RESOURCE_GROUP="school-hall-booking-rg"
APP_NAME="school-hall-booking-$(date +%s)"
LOCATION="East US"

echo "🚀 Starting Azure deployment..."

# Login to Azure (uncomment if needed)
# az login

# Create resource group
echo "📁 Creating resource group..."
az group create --name $RESOURCE_GROUP --location "$LOCATION"

# Create App Service Plan
echo "📋 Creating App Service Plan..."
az appservice plan create --name "${APP_NAME}-plan" --resource-group $RESOURCE_GROUP --sku B1 --is-linux

# Create Web App
echo "🌐 Creating Web App..."
az webapp create --resource-group $RESOURCE_GROUP --plan "${APP_NAME}-plan" --name $APP_NAME --runtime "DOTNET|9.0"

# Configure app settings
echo "⚙️ Configuring app settings..."
az webapp config appsettings set --resource-group $RESOURCE_GROUP --name $APP_NAME --settings ASPNETCORE_ENVIRONMENT=Production

# Deploy the application
echo "📦 Deploying application..."
az webapp deployment source config-zip --resource-group $RESOURCE_GROUP --name $APP_NAME --src ./school-booking.zip

echo "✅ Deployment completed!"
echo "🌐 Your app is available at: https://$APP_NAME.azurewebsites.net"
echo "📊 Monitor your app at: https://portal.azure.com"
