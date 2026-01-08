# Öğrenci Burs Otomasyonu

Öğrenci burs başvurularını/öğrencileri, burs tanımlarını, burs-öğrenci eşleştirmelerini ve burs ödeme takibini yöneten **ASP.NET Core Web API + DevExpress WinForms Desktop** uygulaması.

## Mimari

- **API**: `OgrenciBursOtomasyonu.Api` (ASP.NET Core, EF Core, SQL Server)
  - Swagger: `http://localhost:5215/swagger`
  - Statik sayfalar: `OgrenciBursOtomasyonu.Api/wwwroot` (ör. başvuru ekranları)
- **Desktop**: `OgrenciBursOtomasyonu.Desktop` (DevExpress WinForms)
  - Modüller: Ana Sayfa, Öğrenciler, Burslar, Kullanıcı İşlemleri

## Özellikler (özet)

- **Öğrenci yönetimi**: listeleme, detay, düzenleme/silme
- **Burs yönetimi**: burs tanımlama, burs eşleştirme, bursiyer listeleme/ödeme takibi
- **Kullanıcı işlemleri**: kullanıcı ekle/güncelle/sil + giriş (login)
- **Dashboard**: istatistikler/grafikler

## Gereksinimler

- **.NET SDK 9.x**
- **SQL Server / SQL Express** (varsayılan bağlantı SQL Server)
- **DevExpress WinForms** (Desktop projesi için)

## Kurulum / Çalıştırma

### 1) Veritabanı bağlantısını ayarla

`OgrenciBursOtomasyonu.Api/appsettings.json` içindeki `ConnectionStrings:DefaultConnection` değerini kendi ortamına göre düzenle.

> Öneri: Gerçek anahtar/şifreleri repo’ya **commit etmeyin** (aşağıdaki “Güvenlik” bölümüne bakın).

### 2) Migration uygula (DB oluştur)

API projesi klasöründe:

```bash
dotnet tool update --global dotnet-ef
dotnet ef database update --project .\OgrenciBursOtomasyonu.Api\OgrenciBursOtomasyonu.Api.csproj
```

### 3) API’yi çalıştır

```bash
dotnet run --project .\OgrenciBursOtomasyonu.Api\OgrenciBursOtomasyonu.Api.csproj
```

Varsayılan: `http://localhost:5215`

### 4) Desktop’ı çalıştır

```bash
dotnet run --project .\OgrenciBursOtomasyonu.Desktop\OgrenciBursOtomasyonu.Desktop.csproj
```

> Desktop uygulaması API’ye `http://localhost:5215` üzerinden bağlanır.

## Varsayılan kullanıcı

Veritabanı seed’i ile **varsayılan admin** kullanıcı oluşturulur:

- **Kullanıcı adı**: `admin`
- **Şifre**: `12345`

## Güvenlik (GitHub’a atmadan önce önemli)

Bu repo’da `appsettings.json` içindeki **API anahtarı / e-posta şifresi** gibi değerleri GitHub’a göndermeyin.

Önerilen yöntem:

- `OgrenciBursOtomasyonu.Api/appsettings.json` içinde anahtarları **boş/placeholder** bırakın
- Geliştirme ortamında **User Secrets** veya `appsettings.Development.json` / ortam değişkenleri kullanın

Örnek (User Secrets):

```bash
dotnet user-secrets init --project .\OgrenciBursOtomasyonu.Api\OgrenciBursOtomasyonu.Api.csproj
dotnet user-secrets set "Gemini:ApiKey" "YOUR_KEY" --project .\OgrenciBursOtomasyonu.Api\OgrenciBursOtomasyonu.Api.csproj
dotnet user-secrets set "Email:SmtpKullaniciAdi" "YOUR_EMAIL" --project .\OgrenciBursOtomasyonu.Api\OgrenciBursOtomasyonu.Api.csproj
dotnet user-secrets set "Email:SmtpSifre" "YOUR_APP_PASSWORD" --project .\OgrenciBursOtomasyonu.Api\OgrenciBursOtomasyonu.Api.csproj
```

## Sık karşılaşılan sorunlar

- **API Timeout / yanıt vermiyor**: Desktop tarafında çok sayıda paralel istek API’yi zorlayabilir. Bu repo’da Öğrenciler detay istekleri throttle edilmiştir.
- **DevExpress lisans uyarıları (DX1000/DX1001)**: Geliştirme makinesinde DevExpress lisans aktivasyonu gerekir.

## Repo yapısı

- `OgrenciBursOtomasyonu.Api/` → Web API + Swagger + `wwwroot`
- `OgrenciBursOtomasyonu.Desktop/` → DevExpress WinForms Desktop
- `OgrenciBursOtomasyonu.sln` → çözüm dosyası


