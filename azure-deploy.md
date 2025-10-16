# دليل رفع المشروع على Azure - App Service جديد

## 📋 **الخطوات:**

### **1. إنشاء App Service جديد في Azure Portal:**

#### **أ. اذهب إلى Azure Portal:**
```
https://portal.azure.com
```

#### **ب. إنشاء App Service جديد:**
1. اضغط "Create a resource"
2. ابحث عن "Web App"
3. اضغط "Create"

#### **ج. ملء البيانات:**
```
- Subscription: اختر اشتراكك
- Resource Group: أنشئ جديد أو اختر موجود
- Name: school-hall-booking-v2 (أو أي اسم تريده)
- Publish: Code
- Runtime stack: .NET 9
- Operating System: Linux (أو Windows)
- Region: اختر المنطقة الأقرب لك
```

#### **د. اختيار الخطة:**
```
- App Service Plan: Create new
- Name: SchoolHallBooking-Plan-V2
- Pricing tier: S1 (Standard)
- ✅ اختر "1 Year Reserved Instance" للتوفير
```

---

### **2. إعداد المشروع للنشر:**

#### **أ. تنظيف المشروع:**
```bash
cd /Users/macbookprom3/school-hall-booking/SchoolHallBooking
dotnet clean
```

#### **ب. بناء المشروع:**
```bash
dotnet build --configuration Release
```

#### **ج. نشر المشروع:**
```bash
dotnet publish --configuration Release --output ./publish
```

---

### **3. رفع المشروع إلى Azure:**

#### **الطريقة 1: باستخدام Azure CLI (الأسرع):**

##### **أ. تسجيل الدخول:**
```bash
az login
```

##### **ب. رفع المشروع:**
```bash
az webapp deployment source config-zip \
  --resource-group <اسم-المجموعة> \
  --name school-hall-booking-v2 \
  --src ./publish.zip
```

#### **الطريقة 2: باستخدام Visual Studio Code:**
1. افتح المشروع في VS Code
2. اضغط على Azure Extension
3. اضغط بزر الماوس الأيمن على App Service الجديد
4. اختر "Deploy to Web App"

#### **الطريقة 3: باستخدام Azure Portal:**
1. اذهب إلى App Service الجديد
2. اختر "Deployment Center"
3. اختر "Local Git" أو "GitHub"
4. اتبع التعليمات

---

### **4. إعداد قاعدة البيانات:**

#### **أ. نسخ قاعدة البيانات:**
```bash
# نسخ ملف قاعدة البيانات الحالي
cp schoolhall.db schoolhall-backup.db
```

#### **ب. رفع قاعدة البيانات:**
1. اذهب إلى App Service الجديد
2. اختر "Advanced Tools (Kudu)"
3. اضغط "Go"
4. اذهب إلى "Debug console" > "CMD"
5. ارفع ملف `schoolhall.db`

---

### **5. إعداد الإعدادات:**

#### **أ. في Azure Portal:**
1. اذهب إلى App Service الجديد
2. اختر "Configuration"
3. أضف:
```
- ASPNETCORE_ENVIRONMENT: Production
- ConnectionStrings__DefaultConnection: Data Source=schoolhall.db
```

---

### **6. اختبار المشروع:**

#### **أ. افتح الرابط:**
```
https://school-hall-booking-v2.azurewebsites.net
```

#### **ب. تحقق من:**
- ✅ الصفحة الرئيسية تعمل
- ✅ تسجيل الدخول يعمل
- ✅ جميع الصفحات تعمل
- ✅ قاعدة البيانات تعمل

---

## 💰 **التكلفة المتوقعة:**

### **S1 Plan (سنوي):**
- **السعر:** ~$600/سنة
- **توفير:** ~$300/سنة (مقارنة بالشهري)

### **مميزات S1:**
- ✅ 1.75 GB RAM
- ✅ 50 GB Storage
- ✅ SSL مجاني
- ✅ Auto-scaling
- ✅ Custom domains

---

## 🔧 **نصائح:**

### **1. احتفظ بالـ App Service القديم:**
- لا تحذفه حتى تتأكد من أن الجديد يعمل
- يمكنك حذفه لاحقاً

### **2. استخدم Custom Domain:**
- يمكنك ربط دومين خاص
- SSL مجاني مع Azure

### **3. مراقبة الأداء:**
- استخدم Application Insights
- تابع الأخطاء والأداء

---

## ⚠️ **تحذيرات:**

### **قبل النشر:**
- ✅ احفظ نسخة احتياطية من قاعدة البيانات
- ✅ اختبر المشروع محلياً
- ✅ تأكد من أن جميع الإضافات تعمل

### **بعد النشر:**
- ✅ اختبر جميع الصفحات
- ✅ تحقق من قاعدة البيانات
- ✅ راقب الأخطاء

---

## 📞 **الدعم:**

إذا واجهت أي مشكلة:
1. تحقق من Logs في Azure Portal
2. استخدم Application Insights
3. تحقق من Configuration Settings

---

**ملاحظة:** هذا الدليل يفترض أنك تستخدم SQLite. إذا كنت تريد استخدام SQL Server، سيحتاج الأمر خطوات إضافية.


