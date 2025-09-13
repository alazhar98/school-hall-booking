# 🚀 نشر سريع على Hostinger VPS

## الخطوة 1: الاتصال بـ VPS

```bash
# تسجيل الدخول إلى VPS
ssh root@your-vps-ip
# أو
ssh username@your-vps-ip
```

## الخطوة 2: تحميل وتشغيل سكريبت النشر

```bash
# تحميل سكريبت النشر
wget https://github.com/alazhar98/school-hall-booking/raw/main/deploy-to-hostinger.sh

# جعله قابل للتنفيذ
chmod +x deploy-to-hostinger.sh

# تشغيل سكريبت النشر
./deploy-to-hostinger.sh
```

## الخطوة 3: إعداد SSL (اختياري)

```bash
# بعد اكتمال النشر، يمكنك إعداد SSL
sudo ./setup-ssl.sh
```

## ✅ النتيجة

بعد اكتمال النشر، سيكون التطبيق متاحاً على:
- **HTTP**: `http://your-vps-ip`
- **HTTPS**: `https://yourdomain.com` (إذا قمت بإعداد SSL)

## 🔧 أوامر مفيدة

```bash
# فحص حالة التطبيق
sudo systemctl status school-booking

# عرض السجلات
sudo journalctl -u school-booking -f

# إعادة تشغيل التطبيق
sudo systemctl restart school-booking

# فحص Nginx
sudo systemctl status nginx
```

## 📞 الدعم

إذا واجهت أي مشاكل، تحقق من:
1. السجلات: `sudo journalctl -u school-booking -f`
2. حالة الخدمات: `sudo systemctl status school-booking nginx`
3. الصلاحيات: `ls -la /var/www/school-booking/`
