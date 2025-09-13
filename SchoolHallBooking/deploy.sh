#!/bin/bash

# School Hall Booking - Deployment Script
# نظام حجز القاعات المدرسية - سكريبت النشر

echo "🚀 بدء عملية النشر..."
echo "Starting deployment process..."

# تنظيف الملفات المؤقتة
echo "🧹 تنظيف الملفات المؤقتة..."
echo "Cleaning temporary files..."
dotnet clean
rm -rf bin/ obj/

# بناء المشروع
echo "🔨 بناء المشروع..."
echo "Building project..."
dotnet build -c Release

# اختبار المشروع
echo "🧪 اختبار المشروع..."
echo "Testing project..."
dotnet test --no-build

# نشر المشروع
echo "📦 نشر المشروع..."
echo "Publishing project..."
dotnet publish -c Release -o ./publish

echo "✅ تم النشر بنجاح!"
echo "Deployment completed successfully!"

echo ""
echo "📋 خطوات النشر على المنصات المختلفة:"
echo "Deployment steps for different platforms:"
echo ""
echo "1. Railway:"
echo "   - اذهب إلى railway.app"
echo "   - اربط المشروع بـ GitHub"
echo "   - سيتم النشر تلقائياً"
echo ""
echo "2. Render:"
echo "   - اذهب إلى render.com"
echo "   - اختر 'Web Service'"
echo "   - اختر 'Docker' كبيئة التشغيل"
echo ""
echo "3. Vercel:"
echo "   - اذهب إلى vercel.com"
echo "   - اربط المشروع بـ GitHub"
echo "   - سيتم النشر تلقائياً"
echo ""
echo "4. Heroku:"
echo "   - اذهب إلى heroku.com"
echo "   - أنشئ تطبيق جديد"
echo "   - اربط المشروع بـ GitHub"
echo "   - اضغط Deploy"
