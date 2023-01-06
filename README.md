# RehberWeb
## Merhaba
proje [https://github.com/setur/assessment-backend-net](https://github.com/setur/assessment-backend-net) 
adresinden alındı ve gerekli tüm aşamaların tasarımı ve kodu yazıldı.

Bu proje microsoft visual studio ortamında yazıldı ve çalıştırıldı. Proje bitiminde herhangi bir eror ile karşılaşılmadı

### Projeye giriş
 
istenilenler doğrultusunda 

Microsoft Visual Studio da ASP.NET CORE WEB API projesi açıldı ve aşağıda belirttiğim ilgili paketler kuruldu

"Microsoft.EntityFrameworkCore.SqlServer"

"Microsoft.EntityFrameworkCore.Design"

"Microsoft.EntityFrameworkCore.Tools"

"ServiceStack.Redis" Redis Kafka benzeri Message Queue sistemidir 

### Modelleme

Model klasöründe context klasörü oluşturuldu ve DbContext sınıfından üretilmiş RehberDbContext sınıfı oluşturuldu ve içerisinde DbSetler belirlendi
context klasöründe entities klasörü oluşturuldu içerisinde iletişimbilgileri Rapor RaporData ve Rehber sınıfları verilen veri yapılarında göre oluşturuldu
AutoMapping örneği olması ve kullanım kolaylığı olması açısından yalnızca rehber için kullanıldı.
AutoMapper için MapperProfile sınıfı oluşturuldu 
aynı zamanda dataları transfer için verilen veri yapılarına göre RehberDto sınıfı oluşturuldu ve MapperProfile sınıfının
içerisinde RehberDto dan Rehbere map oluşturuldu

### API Controlers

Üç adet api controller oluşturuldu rapor rehber ve iletişimbilgileri controller 
üç controllerda da RehberDbContext den _context objesi oluşturuldu ve constructor method yaratıldı
ek olarak rehbercontroller da mapper objesi oluşturulup constructor methoda eklendi 

Rehbercontrollerda Http post put delete get işlemleri yapıldı 
post rehbere ekleme yapmak için put belirlenen id li rehberi değiştirmek için 
delete belirlenen id li rehberi silmek için 
get rehberdeki butün kişileri ve iletişim bilgilerini çekmek için 
aynı zaman da redisclient ile Cashing yapıldı

IletişimBilgileriController da yalnızca post ve delete işlemleri yapıldı 

Rapor kısmı en çok kafamın karıştığı yerdi istenileni doğru bir şekilde yaptığımı düşünüyorum 
RaporControllerda yanlızca get işlemi gerçekleşti ve asenkron olarak gerçekleştirildi 
method içerisinde iletişimbilgileri konuma göre listeledim ve aynı konumdaki kişi sayısını ve var ise telefon numaralarının sayısını 
RaporData da tuttum 
daha sonra Rapor mapleme yaptım raporun talep edildiği tarih rapor durumu ve rapordata daki verileri ekledim
Sistemin oluşturduğu raporların listelenmesi
Sistemin oluşturduğu bir raporun detay bilgilerinin getirilmesi isteklerini karşılamak için 
her get işlemi yapıldığında daha önceki tüm rapor isteklerini return ettim 

Ve herhangi bir eror almadan sistem çalışır hale getirildi 

### Çalıştığına dair görüntüler

![RehberWeb çalıştırıldığındaki görüntü](https://github.com/Beroweiser/RehberWeb/blob/master/WhatsApp%20Image%202023-01-06%20at%2012.08.15.jpeg)
![Rehber post işlemi ](https://github.com/Beroweiser/RehberWeb/blob/master/WhatsApp%20Image%202023-01-06%20at%2012.14.28.jpeg)
![iletişimbilgileri post işlemi](https://github.com/Beroweiser/RehberWeb/blob/master/WhatsApp%20Image%202023-01-06%20at%2012.12.20.jpeg)
![Rehber get işlemi](https://github.com/Beroweiser/RehberWeb/blob/master/WhatsApp%20Image%202023-01-06%20at%2012.15.09.jpeg)
![girilen id deki kişi silindi ](https://github.com/Beroweiser/RehberWeb/blob/master/WhatsApp%20Image%202023-01-06%20at%2012.15.41.jpeg)
![Put işlemi girelen id deki bilgileri değiştirme](https://github.com/Beroweiser/RehberWeb/blob/master/WhatsApp%20Image%202023-01-06%20at%2012.17.13.jpeg)
![iletişim bilgileri silinebilir](https://github.com/Beroweiser/RehberWeb/blob/master/WhatsApp%20Image%202023-01-06%20at%2012.20.29.jpeg)
![Rapor alma işlemi](https://github.com/Beroweiser/RehberWeb/blob/master/WhatsApp%20Image%202023-01-06%20at%2015.01.41.jpeg)
![Rapor almaişlemi devamı nekadar çok rapor alındıysa liste okadar büyüyor ve hepsi görünür halde](https://github.com/Beroweiser/RehberWeb/blob/master/WhatsApp%20Image%202023-01-06%20at%2015.02.21.jpeg)
