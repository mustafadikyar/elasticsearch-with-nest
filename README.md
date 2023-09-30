# Elasticsearch/Kibana (Nest Kütüphanesi)

Bu proje, ElasticSearch veritabanıyla etkileşimde bulunmak için .NET tabanlı Nest kütüphanesini kullanarak temel CRUD (Create, Read, Update, Delete) işlemlerini içerir.

## Nasıl Başlatılır ve Kullanılır?

1. **Gereksinimler:** Projenin çalıştırılabilmesi için .NET Core SDK ve ElasticSearch sunucusunun erişilebilir olması gereklidir.
  
   ElasticSearch sunucusu yerel makinada veya uzak bir sunucuda çalışabilir.
4. **Proje Ayarları:** `appsettings.json` dosyasında ElasticSearch sunucusu ve diğer yapılandırma ayarlarını yapılandırın.

## Kayıtlar Nereden Görüntülenir?

Kibana'ya `5601` portu üzerinden erişebilir ve inceleyebilirsiniz.

![](https://github.com/mustafadikyar/elasticsearch-with-nest/blob/master/kibana.png)

## API Endpoints
  
* *Ürün Oluşturma:*

```http
POST

  /api/products
```

* *Tüm Ürünleri Görüntüleme:*

```http
GET

  /api/products
```

* *Ürün Güncelleme:*

```http
PUT

  /api/products
```

* *Ürün Silme:*

```http
DELETE

  /api/products
```
