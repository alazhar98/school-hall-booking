#!/bin/bash

# School Hall Booking - VPS Installation Script
# Run this script on your Hostinger VPS

set -e

echo "🚀 Starting School Hall Booking installation..."

# Update system
echo "📦 Updating system packages..."
sudo apt update && sudo apt upgrade -y

# Install .NET 9 runtime
echo "🔧 Installing .NET 9 runtime..."
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt update
sudo apt install -y dotnet-runtime-9.0

# Install Nginx
echo "🌐 Installing Nginx..."
sudo apt install -y nginx

# Create application directory
echo "📁 Creating application directory..."
sudo mkdir -p /var/www/school-booking
sudo mkdir -p /var/www/school-booking/data

# Set permissions
echo "🔐 Setting permissions..."
sudo chown -R www-data:www-data /var/www/school-booking
sudo chmod -R 755 /var/www/school-booking

# Copy application files (assuming they're already uploaded)
echo "📋 Copying application files..."
sudo cp -r * /var/www/school-booking/
sudo chown -R www-data:www-data /var/www/school-booking

# Install systemd service
echo "⚙️ Installing systemd service..."
sudo cp school-booking.service /etc/systemd/system/
sudo systemctl daemon-reload
sudo systemctl enable school-booking.service

# Configure Nginx
echo "🌐 Configuring Nginx..."
sudo cp nginx-school-booking.conf /etc/nginx/sites-available/school-booking
sudo ln -sf /etc/nginx/sites-available/school-booking /etc/nginx/sites-enabled/
sudo rm -f /etc/nginx/sites-enabled/default

# Test Nginx configuration
echo "🧪 Testing Nginx configuration..."
sudo nginx -t

# Start services
echo "🚀 Starting services..."
sudo systemctl start school-booking.service
sudo systemctl restart nginx

# Enable firewall
echo "🔥 Configuring firewall..."
sudo ufw allow 'Nginx Full'
sudo ufw allow ssh
sudo ufw --force enable

echo "✅ Installation completed successfully!"
echo "🌐 Your application should be running at: http://your-domain.com"
echo "📊 Check service status with: sudo systemctl status school-booking"
echo "📝 View logs with: sudo journalctl -u school-booking -f"
