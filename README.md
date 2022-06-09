
# Restoran Yönetim Sistemi

Web uygulaması olarak geliştirilen bu projede restoranın yönetiminde kullanılan ekle, sil ve güncelle gibi sipariş takip sağlanabilir. Kategori ve ürün kontrolleri yapılabilir. Kategori ekleme, silme ve güncelleme yapılabilmektedir. Seçilen kategoriye ürün eklenilebilir. Telefon siparişi, Masa siparişi ve Online entegrasyon sipariş takipleri yapılabilir. Uygulamayı kullanacak kullanıcı ve garsonlara yetki verilebilir. 

## Özellikler

- Ekle Sil Güncelle (Kategori,Ürün,Müşteri,Sokak,Mahalle...)
- Telefon Siparişi Takip
- Masa Siparişi Takip

## Uygulama Görüntüleri

![Uygulama Ekran Görüntüsü](https://via.placeholder.com/468x300?text=App+Screenshot+Here)

## Proje Tanıtımı

Bu proje N katmanlı mimari yapısına uygun olarak .net5 ile oluşturulmuştur. Katmanlar sorumlulukların ayrılması ve bağımlılıkların yönetilmesi için kullanılan bir yöntemdir. Her katmanın belirli bir sorumluluğu vardır. Daha yüksek bir katman, hizmetleri daha düşük bir katmanda kullanabilir ancak daha düşük bir katman, hizmetleri daha yüksek bir katmanda kullanamaz. Katmanlara ayrılmış projede varlık, veri tabanı erişimi, iş katmanı ve sunum katmanı olmak üzere 4 katman bulunuyor. Veri tabanı Code First yaklaşımı ile oluşturulmuştur.

## Özellikler

- Multitier Architecture
- .Net Core 5
- Code First
- Responsive Layout
  
## Kullanılanlar

.Net 5, .Net Core 5, EntityFrameworkCore, FluentValidation, Bootstrap, Jquery 
  
## Varlık Katmanı - EntityLayer

Bu katmanda veri tabanında bulunan her tablonun sınıfları ve nitelikleri oluşturulmuştur.
Üst katmanlar(DataAccessLayer, BussinesLayer ve Sunum katmanı) kullanabilir. 

### İki tablo arasındaki ilişkiyi oluşturma örneği

```javascript
    public class Category
    {
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
```
Bire çok (1-n) ilişkili tablolarda kullanılan yapı böyledir.

## Veri Erişim Katmanı - DataAccessLayer
Projenin veri tabanı ile bağlantı kuran katmanıdır. Concrete klasörü altında Context.cs sınıf bulunur ve veri tabanı bağlantısını tutar. 

### Context.cs

```javascript
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=UFUK;database=Rys;integrated security=true");
    }
```
Code First yaklaşımı ile hazırladığım için Rys adında veri tabanı oluşturur. Veri tabanında tablolarıda bu sınıfta DbSet olarak tutarız.

```javascript
    public DbSet<Category> Categories { get; set; }
```

## Migrations

Hazırlanan Context.cs sınıfını veri tabanına yansıtmak için DataAccessLayer'da 

İlk Adım:

```bash
  Add-Migration MigrationName
```

Sonraki adım:

```bash
  Update-Database
```
Hazırlanan sınıflar veri tabanına yansıması lazım...

## API Kullanımı

#### Tüm öğeleri getir

```http
  GET /api/items
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Gerekli**. API anahtarınız. |

#### Öğeyi getir

```http
  GET /api/items/${id}
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Gerekli**. Çağrılacak öğenin anahtar değeri |

#### add(num1, num2)

İki sayı alır ve toplamı döndürür.

  
## Lisans

[MIT](https://choosealicense.com/licenses/mit/)

  
## İlişkili Projeler

İşte bazı ilgili projeler

[Awesome README](https://github.com/matiassingers/awesome-readme)

  
## Destek

Destek için fake@fake.com adresine e-posta gönderin veya Slack kanalımıza katılın.

  
## Optimizasyon

Kodunuzda hangi optimizasyonları yaptınız? Örneğin. yeniden düzenleyiciler, performans iyileştirmeleri, erişilebilirlik

  
