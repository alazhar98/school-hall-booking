#!/bin/bash

# School Hall Booking - Hostinger VPS Deployment Script
# This script will help you deploy the application to your Hostinger VPS

set -e

echo "🚀 School Hall Booking - Hostinger VPS Deployment"
echo "=================================================="

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

# Function to print colored output
print_status() {
    echo -e "${BLUE}[INFO]${NC} $1"
}

print_success() {
    echo -e "${GREEN}[SUCCESS]${NC} $1"
}

print_warning() {
    echo -e "${YELLOW}[WARNING]${NC} $1"
}

print_error() {
    echo -e "${RED}[ERROR]${NC} $1"
}

# Check if running on VPS
if [[ "$EUID" -eq 0 ]]; then
    print_warning "Running as root. This is recommended for VPS deployment."
else
    print_warning "Not running as root. You may need sudo privileges."
fi

# Get VPS information
print_status "Getting VPS information..."
echo "Current user: $(whoami)"
echo "Current directory: $(pwd)"
echo "Available disk space:"
df -h /

# Check if .NET is installed
print_status "Checking .NET installation..."
if command -v dotnet &> /dev/null; then
    DOTNET_VERSION=$(dotnet --version)
    print_success ".NET is installed: $DOTNET_VERSION"
else
    print_warning ".NET is not installed. Will install .NET 9 runtime."
fi

# Check if Nginx is installed
print_status "Checking Nginx installation..."
if command -v nginx &> /dev/null; then
    NGINX_VERSION=$(nginx -v 2>&1)
    print_success "Nginx is installed: $NGINX_VERSION"
else
    print_warning "Nginx is not installed. Will install Nginx."
fi

# Download and extract the application
print_status "Downloading application files..."
if [ ! -f "school-booking-vps.zip" ]; then
    print_status "Downloading school-booking-vps.zip from GitHub..."
    wget -O school-booking-vps.zip https://github.com/alazhar98/school-hall-booking/raw/main/school-booking-vps.zip
    print_success "Download completed"
else
    print_success "school-booking-vps.zip already exists"
fi

# Extract the application
print_status "Extracting application files..."
if [ -d "school-booking-vps" ]; then
    print_warning "school-booking-vps directory already exists. Removing it..."
    rm -rf school-booking-vps
fi

unzip school-booking-vps.zip
cd school-booking-vps
print_success "Extraction completed"

# Run the installation script
print_status "Running installation script..."
chmod +x install.sh
sudo ./install.sh

# Check if installation was successful
if [ $? -eq 0 ]; then
    print_success "Installation completed successfully!"
else
    print_error "Installation failed!"
    exit 1
fi

# Ask about SSL setup
echo ""
print_status "SSL Setup"
echo "=========="
read -p "Do you want to setup SSL (HTTPS) now? (y/n): " setup_ssl

if [[ $setup_ssl =~ ^[Yy]$ ]]; then
    print_status "Setting up SSL..."
    chmod +x setup-ssl.sh
    sudo ./setup-ssl.sh
else
    print_warning "SSL setup skipped. You can run it later with: sudo ./setup-ssl.sh"
fi

# Final status check
print_status "Final status check..."
echo ""

# Check service status
print_status "Checking service status..."
if systemctl is-active --quiet school-booking; then
    print_success "School Hall Booking service is running"
else
    print_error "School Hall Booking service is not running"
fi

if systemctl is-active --quiet nginx; then
    print_success "Nginx service is running"
else
    print_error "Nginx service is not running"
fi

# Show application URLs
echo ""
print_success "Deployment completed!"
echo "========================"
echo ""
echo "🌐 Your application should be available at:"
echo "   HTTP:  http://$(hostname -I | awk '{print $1}')"
echo "   HTTP:  http://localhost"
if [[ $setup_ssl =~ ^[Yy]$ ]]; then
    echo "   HTTPS: https://yourdomain.com (replace with your actual domain)"
fi
echo ""
echo "📊 Useful commands:"
echo "   Check status:    sudo systemctl status school-booking"
echo "   View logs:       sudo journalctl -u school-booking -f"
echo "   Restart app:     sudo systemctl restart school-booking"
echo "   Check Nginx:     sudo systemctl status nginx"
echo ""
echo "📁 Application files are located at:"
echo "   /var/www/school-booking/"
echo ""
echo "🗄️ Database file:"
echo "   /var/www/school-booking/data/SchoolHallBooking.db"
echo ""

print_success "Deployment script completed successfully!"
