## Katmanlar

### NTier.Entities
Bu katman, projede kullanýlacak olan entity (varlýk) sýnýflarýný içerir. Entity sýnýflaruý genellikle veritabanýndaki tablolarý temsil ederler. Bu anlamda her bir entity sýnýfý, veritabanýndaki her bir tabloyu temsil etmektedir.

### NTier.DAL
Data Access Layer (veriye eriþim katmaný) olarak adlandýrýlan bu katman, veritabanýyla iletiþimden sorumludur. Vertiabanýna eriþim, sorgualrýn hazýrlanmasý, veri okuma/yazma gibi iþlemleri bünyesinde gerçekleþtirir.


### NTier.BLL
Business Logic Layer (Ýþ Mantýðý katmaný) olarak adlandýrýlan bu katman, uygulamanýn iþ mantýðýný içerir. Kullanýcý taleplerini iþleyen ve veri eriþim katmaný ile iletiþim kurmakla yükümlüdür. Genellikle iþ kurallarýný ve iþ süreçlerini belirler.


### NTier.Common
Bu katman, projen,n farklý katmanlarý arasýnda paylaþýmlarý içeren genel katmandýr. Örneðin eposta gönderimi, Ipadresi yakalama, görsel ekleme gibi iþlemler bu katman içerisinde tanýmlanýr.

### NTier.IOC
Inversion Of Control projede kullanýlan baðýmlýlýklarýn dahil edilmesi veya bu baðýmlýlýklarýn çözümlenmesini gerçekleþtiren katmandýr.