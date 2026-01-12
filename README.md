# 📚 Kütüphane Yönetim Sistemi API (Library Management System)

Bu proje, **.NET 9** kullanılarak geliştirilmiş, **Katmanlı Mimari (Layered Architecture)** prensiplerine uygun, güvenli ve ölçeklenebilir bir RESTful Web API projesidir. Kütüphane işlemlerini (Kitap, Yazar, Kullanıcı, Ödünç Alma) yönetmek için tasarlanmıştır.

## 🚀 Proje Özellikleri ve Teknik Detaylar

Bu proje, modern yazılım geliştirme standartlarına ve ödev gereksinimlerine tam uyum sağlar:

* **Mimari:** Controller, Service, DTO ve Data katmanlarından oluşan **Katmanlı Mimari**.
* **Minimal API & Controller:** Hibrit yapı kullanılarak hem geleneksel Controller hem de **Minimal API** (Author endpoints) örnekleri sunulmuştur.
* **Veritabanı:** **SQLite** ve **Entity Framework Core (Code First)** yaklaşımı.
* **Güvenlik:** **JWT (JSON Web Token)** tabanlı kimlik doğrulama ve Role-Based Authorization (Admin/User).
* **Veri Bütünlüğü:**
    * **DTO (Data Transfer Objects):** API hiçbir zaman doğrudan Entity dönmez, veri güvenliği DTO'lar ile sağlanır.
    * **Soft Delete:** Veriler veritabanından silinmez, `IsDeleted` bayrağı ile işaretlenir.
    * **Audit Fields:** Tüm tablolarda `CreatedAt` ve `UpdatedAt` loglaması mevcuttur.
* **Hata Yönetimi:** **Global Exception Middleware** ile tüm sunucu hataları merkezi olarak yakalanır ve standart formatta sunulur.
* **Standart Response:** Tüm API cevapları `{ success, message, data }` formatında standardize edilmiştir.
* **Logging:** Kritik işlemlerde (Ekleme, Silme, Listeleme) **ILogger** entegrasyonu.
* **REST Standartları:** Kaynak oluşturma işlemlerinde **201 Created** durum kodu kullanımı.

## 🛠 Kullanılan Teknolojiler

* .NET 9.0 SDK
* ASP.NET Core Web API
* Entity Framework Core (SQLite)
* JWT Bearer Authentication
* Swagger / OpenAPI (Test Arayüzü)

## 📂 Proje Yapısı

* `Controllers/`: API uç noktaları.
* `Services/`: İş mantığı (Business Logic).
* `Models/`: Veritabanı varlıkları (Entities).
* `DTOs/`: Veri transfer objeleri.
* `Context/`: Veritabanı bağlamı ve Seed Data.
* `Middlewares/`: Merkezi hata yakalama katmanı.

## ⚙️ Kurulum ve Çalıştırma

1.  Projeyi klonlayın:
    ```bash
    git clone [https://github.com/KULLANICI_ADINIZ/KutuphaneAPI.git](https://github.com/KULLANICI_ADINIZ/KutuphaneAPI.git)
    cd KutuphaneAPI
    ```

2.  Bağımlılıkları yükleyin ve veritabanını oluşturun:
    *(Uygulama ilk açılışta veritabanını otomatik oluşturur ve örnek verileri (Seed Data) ekler.)*
    ```bash
    dotnet build
    dotnet run
    ```

3.  Swagger arayüzüne gidin:
    `http://localhost:5xxx/swagger` adresinden API'yi test edebilirsiniz.

## 🔑 Kullanıcı Bilgileri (Varsayılan)

Uygulama ayağa kalktığında aşağıdaki kullanıcılar otomatik oluşturulur:

| Rol | Kullanıcı Adı / Email | Şifre |
| :--- | :--- | :--- |
| **Admin** | `admin` | `admin1905` |
| **User** | `ahmet@gmail.com` | `123` |

> **Not:** Swagger üzerinden kilit simgesine tıklayarak dönen Token ile yetkilendirme yapmayı unutmayın.

---
*Geliştirici: [İbrahim Halil YOLAÇAN]