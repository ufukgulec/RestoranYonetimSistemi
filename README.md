
# Restoran Yönetim Sistemi

Web uygulaması olarak geliştirilen bu projede kategori ve ürün kontrolleri yapılabilir. Kategori ekleme, silme ve güncelleme yapılabilmektedir. Seçilen kategoriye ürün eklenilebilir. Telefon siparişi, Masa siparişi ve Online entegrasyon sipariş takipleri yapılabilir. Uygulamayı kullanacak kullanıcı ve garsonlara yetki verilebilir. 
## Uygulama Görüntüleri

![Uygulama Ekran Görüntüsü](https://via.placeholder.com/468x300?text=App+Screenshot+Here)

  
## Proje Tanıtımı

Bu proje N katmanlı mimari yapısına uygun olarak .net5 ile oluşturulmuştur. Katmanlar sorumlulukların ayrılması ve bağımlılıkların yönetilmesi için kullanılan bir yöntemdir. Her katmanın belirli bir sorumluluğu vardır. Daha yüksek bir katman, hizmetleri daha düşük bir katmanda kullanabilir ancak daha düşük bir katman, hizmetleri daha yüksek bir katmanda kullanamaz. Katmanlara ayrılmış projede varlık, veri tabanı erişimi, iş katmanı ve sunum katmanı olmak üzere 4 katman bulunuyor. Veri tabanı Code First yaklaşımı ile oluşturulmuştur.
## Özellikler

- Açık/koyu mod geçişi
- Canlı ön izleme
- Tam ekran modu
- Tüm platformlara destek

  
## Kullanılanlar

**Backend:** .Net 5, .Net Core 5, EntityFrameworkCore, FluentValidation

**Frontend:** Bootstrap, Jquery 

  
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
Bu katman veri tabanı ile iletişim kurulan katmandır. 




.
## migrations

Testleri çalıştırmak için aşağıdaki komutu çalıştırın

```bash
  npm run test
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

  