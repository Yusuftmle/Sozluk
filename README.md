Sozluk Project
Bu proje, modern yazılım geliştirme prensiplerini ve tekniklerini uygulayarak geliştirilmiş bir sözlük uygulamasıdır. Projede güçlü bir mimari yapı ve popüler yazılım geliştirme araçları kullanılmıştır.

🛠️ Kullanılan Teknolojiler ve Araçlar
Mimari Yapı
Onion Architecture: Katmanlı ve bağımsız bir yapı oluşturulmasını sağlar. Domain merkezlidir ve bağımlılıkları dışa doğru organize eder.
CQRS (Command Query Responsibility Segregation): Veriyi sorgulama ve yazma işlemlerinin ayrıştırılması için uygulanmıştır.
Event-Driven Architecture: Sistemdeki işlemler RabbitMQ aracılığıyla asenkron mesajlaşma yöntemiyle yürütülmüştür.
Kullanılan Kütüphaneler ve Frameworkler
Entity Framework Core: Veritabanı işlemleri için ORM aracı olarak kullanıldı.
Dapper: Performans gerektiren noktalarda mikro ORM çözümü olarak tercih edildi.
MediatR: CQRS ve mediator tasarım deseni için kullanıldı.
AutoMapper: Nesne dönüşümleri için tercih edildi.
FluentValidation: Girdi doğrulama işlemlerini kolaylaştırmak için kullanıldı.
RabbitMQ: Event-driven yapı için asenkron mesajlaşma sistemi olarak kullanıldı.
Veritabanı
Microsoft SQL Server: Projede kullanılan ilişkisel veritabanı yönetim sistemi.
Projeksiyonlar ve İşleyiciler
Projeksiyonlar ve diğer işlemler, worker servisleri üzerinden işlenmiştir.
RabbitMQ ile gelen mesajlar bu worker servisler tarafından dinlenir ve ilgili işlemler gerçekleştirilir.
Programlama Dili
C#: Proje tamamen C# diliyle yazılmıştır.
🚀 Proje Özellikleri
Kullanıcı Yönetimi: Kullanıcılar kayıt olabilir, giriş yapabilir ve profillerini yönetebilir.
Entry ve Yorum Yönetimi: Kullanıcılar sözlük girdileri ve yorumları oluşturabilir.
Oylama Sistemi: Entry ve yorumlar üzerinde oylama yapma özelliği.
Asenkron İşlemler: RabbitMQ ile mesaj tabanlı iş akışları.
Validation: Kullanıcı girişi ve veri doğrulama işlemleri FluentValidation ile kolaylaştırılmıştır.
📂 Proje Yapısı
Proje aşağıdaki katmanlardan oluşmaktadır:

API Katmanı: Kullanıcıların etkileşim kurduğu giriş noktası.
Application Katmanı: İş kuralları ve CQRS pattern işlemlerinin yönetildiği katman.
Domain Katmanı: Çekirdek iş mantığının bulunduğu katman.
Infrastructure Katmanı: Veritabanı, RabbitMQ gibi dış kaynaklarla etkileşimi yöneten katman.
🛠️ Kurulum ve Çalıştırma
Kaynak kodu klonlayın:

bash
Kodu kopyala
git clone https://github.com/Yusuftmle/Sozluk.git
MS SQL veritabanı bağlantısını yapılandırın.
appsettings.json dosyasındaki ConnectionStrings bölümünü düzenleyin.

Proje bağımlılıklarını yükleyin:

bash
Kodu kopyala
dotnet restore
RabbitMQ sunucusunu başlatın. RabbitMQ'nun sisteminizde kurulu ve çalışır durumda olduğundan emin olun.

Uygulamayı çalıştırın:

bash
Kodu kopyala
dotnet run
💡 Geliştirici Notları
Proje, kolay genişletilebilir ve sürdürülebilir bir yapı sağlamak için SOLID prensiplerine uygun olarak tasarlanmıştır.
CQRS ve Event-driven yapı ile birlikte Onion Architecture, iş mantığını bağımsız katmanlar halinde düzenlemeye olanak tanır.
