# 🔧 حل مشكلة الملفات الثابتة في SmarterASP

## المشكلة:
الملفات الثابتة (CSS, JS, الصور) لا تظهر على الموقع بعد النشر.

## الحلول:

### 1. نقل `app.css` إلى المكان الصحيح:
```bash
mv wwwroot/app.css wwwroot/css/app.css
```
**✅ تم** - الملف الآن في `wwwroot/css/app.css`

### 2. تحديث `web.config`:
أضف الإعدادات التالية لتمكين الملفات الثابتة:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <location path="." inheritInChildApplications="false">
    <system.webServer>
      <!-- Enable static file handling -->
      <staticContent>
        <remove fileExtension=".css" />
        <mimeMap fileExtension=".css" mimeType="text/css" />
        <remove fileExtension=".js" />
        <mimeMap fileExtension=".js" mimeType="application/javascript" />
        <remove fileExtension=".json" />
        <mimeMap fileExtension=".json" mimeType="application/json" />
        <remove fileExtension=".woff" />
        <mimeMap fileExtension=".woff" mimeType="application/font-woff" />
        <remove fileExtension=".woff2" />
        <mimeMap fileExtension=".woff2" mimeType="application/font-woff2" />
      </staticContent>
      <handlers>
        <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
      </handlers>
      <aspNetCore processPath="dotnet" arguments=".\SchoolHallBooking.dll" stdoutLogEnabled="true" stdoutLogFile=".\logs\stdout" hostingModel="inprocess">
        <environmentVariables>
          <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Production" />
        </environmentVariables>
      </aspNetCore>
      <!-- Rewrite rules for static files -->
      <rewrite>
        <rules>
          <rule name="wwwroot" stopProcessing="true">
            <match url="^(css|js|lib|images|uploads)/.*" />
            <action type="Rewrite" url="wwwroot/{R:0}" />
          </rule>
        </rules>
      </rewrite>
    </system.webServer>
  </location>
</configuration>
```

**✅ تم** - ملف `web.config` محدث

### 3. إنشاء نسخة نشر جديدة:

```bash
# من مجلد المشروع
dotnet publish -c Release -o publish-smarterasp --no-self-contained

# ضغط الملفات
cd publish-smarterasp
zip -r ../school-hall-booking-smarterasp-fixed.zip .
```

### 4. خطوات الرفع على SmarterASP:

1. **امسح المحتوى القديم في File Manager**
2. **ارفع ملف ZIP الجديد**
3. **استخرج الملفات**
4. **تأكد من وجود المجلدات التالية:**
   - `wwwroot/css/` (فيه app.css)
   - `wwwroot/js/` (فيه interop.js و print.js)
   - `wwwroot/lib/bootstrap/`
   - `wwwroot/images/` (فيه logo.png)
   - `logs/` (مع صلاحيات الكتابة)

5. **تحقق من Application Pool:**
   - Control Panel → Websites
   - اختر موقعك
   - Application Pool = `.NET Core`

6. **أعد تشغيل الموقع**

## ملاحظات:

- ملف `SchoolHallBooking.styles.css` يتم توليده تلقائيًا أثناء النشر
- إذا لم يتم توليده، تأكد من أن النشر يستخدم `Release` configuration
- الملفات في `wwwroot` يجب أن تكون موجودة في مجلد النشر النهائي

## للتحقق من المشكلة:

افتح أدوات المطور في المتصفح (F12) وتحقق من:
1. **Console** - هل هناك أخطاء 404؟
2. **Network** - ما هو مسار الملفات التي يحاول تحميلها؟
3. **Sources** - هل ملفات wwwroot موجودة؟

---
**تاريخ الحل:** 19 أكتوبر 2025

