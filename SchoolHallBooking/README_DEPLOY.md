# 🚀 School Hall Booking - VPS Deployment Guide

This guide will help you deploy the School Hall Booking application on a Hostinger VPS (Linux) with full production setup including Nginx, SSL, and systemd service.

## 📋 Prerequisites

- Hostinger VPS with Ubuntu 22.04 LTS
- Root or sudo access
- Domain name pointing to your VPS IP
- Basic knowledge of Linux commands

## 🛠️ Step 1: Connect to Your VPS

### Via SSH (Recommended)
```bash
ssh root@your-vps-ip
# or
ssh username@your-vps-ip
```

### Via SFTP (File Upload)
```bash
sftp username@your-vps-ip
# Upload files to /home/username/
```

## 📦 Step 2: Upload Application Files

### Method 1: Direct Upload
1. Download `school-booking.zip` from your local machine
2. Upload to VPS using SFTP or File Manager
3. Extract the files:
```bash
unzip school-booking.zip
cd school-booking
```

### Method 2: Git Clone (if repository is public)
```bash
git clone https://github.com/yourusername/SchoolHallBooking.git
cd SchoolHallBooking
```

## ⚙️ Step 3: Run Installation Script

The installation script will automatically:
- Install .NET 9 runtime
- Install and configure Nginx
- Set up systemd service
- Configure firewall
- Start the application

```bash
# Make script executable
chmod +x install.sh

# Run installation
sudo ./install.sh
```

## 🔧 Step 4: Manual Installation (Alternative)

If you prefer manual installation:

### Install .NET 9 Runtime
```bash
# Update system
sudo apt update && sudo apt upgrade -y

# Install .NET 9 runtime
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt update
sudo apt install -y dotnet-runtime-9.0
```

### Install Nginx
```bash
sudo apt install -y nginx
```

### Setup Application Directory
```bash
# Create directory
sudo mkdir -p /var/www/school-booking
sudo mkdir -p /var/www/school-booking/data

# Copy files
sudo cp -r * /var/www/school-booking/

# Set permissions
sudo chown -R www-data:www-data /var/www/school-booking
sudo chmod -R 755 /var/www/school-booking
```

### Configure systemd Service
```bash
# Copy service file
sudo cp school-booking.service /etc/systemd/system/

# Reload systemd
sudo systemctl daemon-reload

# Enable and start service
sudo systemctl enable school-booking.service
sudo systemctl start school-booking.service
```

### Configure Nginx
```bash
# Copy Nginx configuration
sudo cp nginx-school-booking.conf /etc/nginx/sites-available/school-booking

# Enable site
sudo ln -sf /etc/nginx/sites-available/school-booking /etc/nginx/sites-enabled/
sudo rm -f /etc/nginx/sites-enabled/default

# Test configuration
sudo nginx -t

# Restart Nginx
sudo systemctl restart nginx
```

## 🔒 Step 5: Setup SSL (HTTPS)

### Automatic SSL Setup
```bash
# Run SSL setup script
sudo ./setup-ssl.sh
```

### Manual SSL Setup
```bash
# Install Certbot
sudo apt install -y certbot python3-certbot-nginx

# Update domain in Nginx config
sudo nano /etc/nginx/sites-available/school-booking
# Replace 'your-domain.com' with your actual domain

# Test Nginx config
sudo nginx -t
sudo systemctl reload nginx

# Obtain SSL certificate
sudo certbot --nginx -d yourdomain.com -d www.yourdomain.com

# Setup auto-renewal
echo "0 12 * * * /usr/bin/certbot renew --quiet" | sudo crontab -
```

## 🗄️ Step 6: Database Management

### Database Location
The SQLite database is located at:
```
/var/www/school-booking/data/SchoolHallBooking.db
```

### Backup Database
```bash
# Create backup
sudo cp /var/www/school-booking/data/SchoolHallBooking.db /var/www/school-booking/data/SchoolHallBooking.db.backup.$(date +%Y%m%d_%H%M%S)
```

### Restore Database
```bash
# Stop application
sudo systemctl stop school-booking

# Restore from backup
sudo cp /path/to/backup.db /var/www/school-booking/data/SchoolHallBooking.db

# Set permissions
sudo chown www-data:www-data /var/www/school-booking/data/SchoolHallBooking.db
sudo chmod 644 /var/www/school-booking/data/SchoolHallBooking.db

# Start application
sudo systemctl start school-booking
```

## 🔧 Step 7: Service Management

### Check Service Status
```bash
sudo systemctl status school-booking
```

### Start/Stop/Restart Service
```bash
sudo systemctl start school-booking
sudo systemctl stop school-booking
sudo systemctl restart school-booking
```

### View Logs
```bash
# View recent logs
sudo journalctl -u school-booking -f

# View logs from today
sudo journalctl -u school-booking --since today

# View last 100 lines
sudo journalctl -u school-booking -n 100
```

### Enable/Disable Auto-start
```bash
# Enable auto-start on boot
sudo systemctl enable school-booking

# Disable auto-start on boot
sudo systemctl disable school-booking
```

## 🌐 Step 8: Nginx Management

### Test Configuration
```bash
sudo nginx -t
```

### Reload Configuration
```bash
sudo systemctl reload nginx
```

### Restart Nginx
```bash
sudo systemctl restart nginx
```

### Check Nginx Status
```bash
sudo systemctl status nginx
```

## 🔥 Step 9: Firewall Configuration

### Basic Firewall Setup
```bash
# Enable UFW
sudo ufw enable

# Allow SSH
sudo ufw allow ssh

# Allow HTTP and HTTPS
sudo ufw allow 'Nginx Full'

# Check status
sudo ufw status
```

## 📊 Step 10: Monitoring and Maintenance

### Check Application Health
```bash
# Check if application is running
curl http://localhost:5000

# Check Nginx
curl http://your-domain.com
```

### Monitor Resources
```bash
# Check disk usage
df -h

# Check memory usage
free -h

# Check running processes
ps aux | grep dotnet
```

### Update Application
```bash
# Stop service
sudo systemctl stop school-booking

# Backup current version
sudo cp -r /var/www/school-booking /var/www/school-booking.backup.$(date +%Y%m%d_%H%M%S)

# Upload new files
# (Upload new version to /var/www/school-booking/)

# Set permissions
sudo chown -R www-data:www-data /var/www/school-booking
sudo chmod -R 755 /var/www/school-booking

# Start service
sudo systemctl start school-booking
```

## 🚨 Troubleshooting

### Application Won't Start
```bash
# Check logs
sudo journalctl -u school-booking -f

# Check if port is in use
sudo netstat -tlnp | grep :5000

# Check file permissions
ls -la /var/www/school-booking/
```

### Nginx Issues
```bash
# Check Nginx logs
sudo tail -f /var/log/nginx/error.log

# Test configuration
sudo nginx -t

# Check if Nginx is running
sudo systemctl status nginx
```

### Database Issues
```bash
# Check database file permissions
ls -la /var/www/school-booking/data/

# Check if database is accessible
sudo -u www-data sqlite3 /var/www/school-booking/data/SchoolHallBooking.db ".tables"
```

### SSL Issues
```bash
# Check certificate status
sudo certbot certificates

# Renew certificate manually
sudo certbot renew

# Check SSL configuration
sudo nginx -t
```

## 📞 Support

If you encounter any issues:

1. Check the logs: `sudo journalctl -u school-booking -f`
2. Verify all services are running: `sudo systemctl status school-booking nginx`
3. Check file permissions: `ls -la /var/www/school-booking/`
4. Test configuration: `sudo nginx -t`

## 🎉 Success!

Once everything is set up correctly, your School Hall Booking application should be accessible at:
- **HTTP**: `http://your-domain.com`
- **HTTPS**: `https://your-domain.com`

The application will automatically start on boot and restart if it crashes.