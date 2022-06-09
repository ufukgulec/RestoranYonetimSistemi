Getting started with Markdown
=============================
- [Titles](# Restoran Yönetim Sistemi)
- [Paragraph](#paragraph)
- [List](#list)
	- [List CheckBox](#list-checkbox)
- [Link](#link)
	- [Anchor links](#anchor-links)
- [Blockquote](#blockquote)
- [Image | GIF](#image--gif)
- [Style Text](#style-text)
	- [Italic](#italic)
	- [Bold](#bold)
	- [Strikethrough](#strikethrough)
- [Code](#code)
- [Email](#email)
- [Table](#table)
	- [Table Align](#table-align)
    	- [Align Center](#align-center)
    	- [Align Left](#align-left)
    	- [Align Right](#align-right)
- [Escape Characters](#escape-characters)
- [Emoji](#emoji)
- [Shields Badges](#Shields-Badges)
- [Markdown Editor](#markdown-editor)
- [Some links for more in depth learning](#some-links-for-more-in-depth-learning)
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

### Migrations

Hazırlanan Context.cs sınıfını veri tabanına yansıtmak için DataAccessLayer'da 

İlk Adım:

```bash
Add-Migration MigrationName
```
DataAccessLayer içinde Migrations klasörünün altında MigrationName adında bir sınıf oluşur. Yapılan değişiklikleri görebilirsiniz.

Sonraki adım:

```bash
Update-Database
```
Yapılan değişiklik veri tabanına yansır.

### DataAccesLayer Yapısı

Abstract klasörünün içine interface sınıflarımı oluşturdum (IGenericDal.cs mesela) repositories klasörü altında oluşturulan GenericRepository.cs sınıfı IGenericDal.cs'den kalıtım alır ve veri tabanı işlemleri (CRUD işlemleri) yapan bir sınıftır. EntityFramework klasörünün içinde oluşturulan varlık repositoryleri (EfCategoryRepository mesela) GenericRepository.cs'den kalıtım alır.

## İş Katmanı - BusinessLayer
Projenin DataAccessLayer ile Sunum katmanını birleştiren katmandır. Validasyon kontrolleri yapar.  

### BusinessLayer Yapısı

Abstract klasörünün içine interface sınıflarımı oluşturdum (IGenericService.cs mesela) Concrete klasörü altında oluşturulan GenericManager.cs sınıfı IGenericService.cs'den kalıtım alır ve veri tabanı işlemleri (CRUD işlemleri) yapan bir sınıftır. EntityFramework klasörünün içinde oluşturulan varlık repositoryleri (EfCategoryRepository mesela) GenericRepository.cs'den kalıtım alır.

### Fluent Validation

ValidationRules klasörü altında varlıkların ekleme çıkarma yaparken kontorllerinin sağlandığı sınıflar vardır. Fluent Validation'ı kullanma amacım kuralları tanımlanmış varlıkların oluşturulurken boş ve geçersiz kullanımlarda hata mesajı dönmesini ve hatalı girdileri veri tabanına yansıtmamak için kullandım. 

```javascript
public class CategoryValidator : AbstractValidator<Category> 
{ 
  public CategoryValidator()
  { 
    RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez"); 
    RuleFor(x => x.Description).MaximumLength(100).WithMessage("100 Karakterden fazla giriş yapmayınız.");
  }
}
```

Kategori adı boş değer olursa "Kategori adı boş geçilemez" mesajı View'e gider.

Controller'da Fluent Validation nasıl kullanılır?

```javascript
CategoryValidator validationRules = new CategoryValidator();
ValidationResult validationResult = validationRules.Validate(category);

validationResult.IsValid -> Boolean değer döner.
```

## Sunum Katmanı - Rys

Projenin sunum katmanı .Net Core5 ile oluşturulmuştur. Model-View-Controller yapısını kullanarak BussinesLayer ve EntityLayer ile ortaklaşa çalışır.

### Controllers

Web projesinin arka planında çalışan kısımdır. BussinesLayer ile bağlantılı çalışır.

Örneğin:

```bash
CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
```
İş katmanında bulunan CategoryManager'ı yeniler. CategoryManager DataAccessLayer'dan Context.cs sınıfını kullanması için EfCategoryRepository.cs sınıfını parametre olarak kullanmalıdır.

### Models

İki ilişkili tabloyu çekerken bazen Include metodu yetersiz kalıyor onun için Models klasörünün içine yeni bir sınıf tanımlanır bu sınıf EntityLayer'daki varlığ kalıtım alır.

Örneğin:

```bash
public class VMPhoneOrder : EntityLayer.Concrete.PhoneOrder
```
Bu klasörde oluşturulan Model View'e gönderilir ve denetleyicide kod karmaşıklığı olmaz.

### Views

Bu klasörün denetleyici isimlerine göre klasörlere ayrılmış bir yapısı vardır. Shared klasörü altında temanın Navbar, Footer, Menu ve Layoutu gibi parçalanmış görünümlerini tutar.

Layout.cshtml nasıl parçalanır?

Temanın Navbarını ayrı dosyada tutmak istiyorsanız Layouta bildirmemiz gerekiyor.

Örneğin:

```bash
<partial name="_Navbar" />
```

View dosyalarında denetleyiciden gelen değerleri okumak için gelen değere göre kod parçacıkları eklemeliyiz.

Denetleyiciden tek bir değer geliyorsa:
```javascript
@using EntityLayer.Concrete;
@model Product
```
Denetleyiciden gelen değer dizi ise:
```javascript
@using EntityLayer.Concrete;
@model List<Product>
```

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

  ![Anurag's GitHub stats](https://github-readme-stats.vercel.app/api?username=ufukgulec&show_icons=true&theme=radical)
  [![Top Langs](https://github-readme-stats.vercel.app/api/top-langs/?username=ufukgulec&layout=compact)]([https://github.com/anuraghazra/github-readme-stats](https://github.com/ufukgulec/RestoranYonetimSistemi))
