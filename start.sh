#!/bin/bash

# School Hall Booking - Start Script
# نظام حجز القاعات المدرسية - سكريبت البدء

echo "🚀 بدء تشغيل نظام حجز القاعات المدرسية..."
echo "Starting School Hall Booking System..."

# تعيين متغيرات البيئة
export ASPNETCORE_ENVIRONMENT=Production
export ASPNETCORE_URLS=http://0.0.0.0:8080

# تشغيل التطبيق
dotnet /app/publish/SchoolHallBooking.dll
