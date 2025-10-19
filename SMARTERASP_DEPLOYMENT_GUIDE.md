# 🚀 دليل الرفع على SmarterASP.NET

## 📋 **الخطوات المطلوبة:**

### **1️⃣ رفع الملفات:**
1. **اذهب إلى Control Panel** → **File Manager**
2. **انتقل إلى مجلد موقعك** (site1)
3. **ارفع ملف `school-hall-booking-smarterasp-final.zip`**
4. **استخرج الملفات** في مجلد موقعك

### **2️⃣ إعداد قاعدة البيانات:**
1. **اذهب إلى Control Panel** → **Database Manager**
2. **اختر MySQL 8.x**
3. **أنشئ قاعدة بيانات جديدة** أو استخدم الموجودة
4. **اذهب إلى phpMyAdmin**
5. **انسخ محتوى ملف `database_setup_final.sql`**
6. **الصق في phpMyAdmin** واضغط Execute

### **3️⃣ تحديث إعدادات الاتصال:**
1. **في File Manager**
2. **افتح ملف `appsettings.Production.json`**
3. **تأكد من صحة بيانات الاتصال:**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=mysql9001.site4now.net;Database=db_abf910_dbschoo;Uid=abf910_dbschoo;Pwd=A96472861a@;"
     }
   }
   ```

### **4️⃣ إعداد Application Pool:**
1. **اذهب إلى Control Panel** → **Websites**
2. **اختر موقعك**
3. **تأكد من أن Application Pool = `.NET Core`**

### **5️⃣ إعطاء الصلاحيات:**
1. **في File Manager**
2. **انقر بزر الماوس الأيمن على مجلد `App_Data`**
3. **اختر Properties/Permissions**
4. **فعّل:**
   - ✅ **Read**
   - ✅ **Write** 
   - ✅ **Execute**
5. **كرر نفس العملية لمجلد `logs`**

### **6️⃣ تفعيل Detail Error:**
1. **في Control Panel** → **Websites**
2. **اختر موقعك**
3. **فعّل "Detail Error"** للحصول على رسائل خطأ مفصلة

## 🔧 **ملفات مهمة:**

- ✅ `web.config` - إعدادات IIS
- ✅ `appsettings.Production.json` - إعدادات قاعدة البيانات
- ✅ `database_setup_final.sql` - سكريبت إنشاء الجداول
- ✅ `App_Data/` - مجلد قاعدة البيانات
- ✅ `logs/` - مجلد ملفات السجل

## 🚨 **إذا واجهت مشاكل:**

### **خطأ 500.30:**
- تحقق من Application Pool = `.NET Core`
- تحقق من وجود `web.config`
- تحقق من وجود مجلد `logs`

### **خطأ قاعدة البيانات:**
- تحقق من صحة بيانات الاتصال
- تأكد من إنشاء الجداول في phpMyAdmin
- تحقق من وجود جدول `__EFMigrationsHistory`

### **خطأ الصلاحيات:**
- تأكد من إعطاء صلاحيات الكتابة لمجلد `App_Data`
- تأكد من إعطاء صلاحيات الكتابة لمجلد `logs`

## 📞 **الدعم:**
إذا استمرت المشاكل، اتصل بدعم SmarterASP.NET واطلب منهم:
- إعطاء صلاحيات الكتابة للمجلدات
- التحقق من إعدادات Application Pool
- مساعدتك في إعداد قاعدة البيانات

---
**تم إنشاء هذا الدليل في:** `$(date)`
**إصدار التطبيق:** .NET 8.0
**نوع قاعدة البيانات:** MySQL 8.x
