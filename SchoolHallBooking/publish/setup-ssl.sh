#!/bin/bash

# SSL Setup Script for School Hall Booking
# Run this script after installing the application

set -e

echo "🔒 Setting up SSL with Let's Encrypt..."

# Install Certbot
echo "📦 Installing Certbot..."
sudo apt install -y certbot python3-certbot-nginx

# Get domain name
read -p "Enter your domain name (e.g., yourdomain.com): " DOMAIN

if [ -z "$DOMAIN" ]; then
    echo "❌ Domain name is required!"
    exit 1
fi

# Update Nginx configuration with domain
echo "🌐 Updating Nginx configuration..."
sudo sed -i "s/your-domain.com/$DOMAIN/g" /etc/nginx/sites-available/school-booking
sudo nginx -t
sudo systemctl reload nginx

# Obtain SSL certificate
echo "🔐 Obtaining SSL certificate..."
sudo certbot --nginx -d $DOMAIN -d www.$DOMAIN --non-interactive --agree-tos --email admin@$DOMAIN

# Setup auto-renewal
echo "🔄 Setting up auto-renewal..."
echo "0 12 * * * /usr/bin/certbot renew --quiet" | sudo crontab -

echo "✅ SSL setup completed successfully!"
echo "🔒 Your application is now available at: https://$DOMAIN"
echo "🔄 SSL certificate will auto-renew every 3 months"
