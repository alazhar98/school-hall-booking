# 📦 تعليمات رفع تطبيق School Hall Booking على SmarterASP.NET مع MySQL

## 🎯 نظرة عامة
هذا الدليل يوضح كيفية رفع تطبيق School Hall Booking على SmarterASP.NET باستخدام MySQL كقاعدة بيانات.

## 📋 المتطلبات المسبقة
- حساب SmarterASP.NET نشط
- معلومات قاعدة بيانات MySQL من SmarterASP.NET
- تطبيق School Hall Booking جاهز للنشر

## 🗄️ إعداد قاعدة البيانات MySQL

### 1️⃣ إنشاء قاعدة بيانات MySQL
1. ادخل إلى لوحة تحكم SmarterASP.NET
2. اذهب إلى قسم **DATABASES**
3. اختر **MySQL** من القائمة المنسدلة
4. اضغط على **"+ Add Database"**
5. أدخل اسم قاعدة البيانات (مثل: `school_hall_booking`)
6. احفظ معلومات الاتصال:
   - **Server**: `mysql.smarterasp.net` (أو ما يعطيك إياه)
   - **Database Name**: `school_hall_booking`
   - **Username**: `your_username`
   - **Password**: `your_password`
   - **Port**: `3306` (عادة)

### 2️⃣ تحديث إعدادات الاتصال
في ملف `appsettings.Production.json`، استبدل:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_MYSQL_SERVER;Database=YOUR_DATABASE_NAME;Uid=YOUR_USERNAME;Pwd=YOUR_PASSWORD;"
  }
}
```

**مثال حقيقي:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=mysql.smarterasp.net;Database=school_hall_booking;Uid=your_username;Pwd=your_password;"
  }
}
```

## 🚀 خطوات الرفع

### 1️⃣ رفع الملفات
1. اذهب إلى قسم **FILES** في لوحة التحكم
2. ارفع جميع ملفات مجلد `publish-mysql` إلى المجلد الرئيسي لموقعك
3. تأكد من رفع الملفات التالية:
   - `SchoolHallBooking.dll`
   - `web.config`
   - مجلد `wwwroot` (مع جميع المحتويات)
   - جميع ملفات `.dll` الأخرى

### 2️⃣ إعداد قاعدة البيانات
1. اذهب إلى قسم **DATABASES** → **MySQL**
2. اضغط على اسم قاعدة البيانات التي أنشأتها
3. استخدم **phpMyAdmin** أو **MySQL Workbench** لإنشاء الجداول
4. أو استخدم Entity Framework Migrations:
   ```bash
   dotnet ef database update
   ```

### 3️⃣ اختبار التطبيق
1. اذهب إلى موقعك على الإنترنت
2. تأكد من أن التطبيق يعمل بشكل صحيح
3. اختبر تسجيل الدخول والوظائف الأساسية

## 🔧 استكشاف الأخطاء

### مشاكل شائعة:
1. **خطأ الاتصال بقاعدة البيانات**:
   - تأكد من صحة معلومات الاتصال
   - تأكد من أن قاعدة البيانات موجودة ومفعلة

2. **خطأ في الصلاحيات**:
   - تأكد من أن المستخدم لديه صلاحيات كاملة على قاعدة البيانات

3. **خطأ في الملفات**:
   - تأكد من رفع جميع الملفات المطلوبة
   - تأكد من صحة ملف `web.config`

## 📞 الدعم
إذا واجهت أي مشاكل، يمكنك:
- مراجعة سجلات الأخطاء في SmarterASP.NET
- التواصل مع دعم SmarterASP.NET
- مراجعة هذا الدليل مرة أخرى

## ✅ التحقق من النجاح
التطبيق يعمل بنجاح عندما:
- ✅ الموقع يفتح بدون أخطاء
- ✅ يمكن تسجيل الدخول
- ✅ جميع الصفحات تعمل بشكل صحيح
- ✅ قاعدة البيانات متصلة وتعمل

---
**ملاحظة**: تأكد من حفظ نسخة احتياطية من قاعدة البيانات قبل أي تحديثات مهمة.
