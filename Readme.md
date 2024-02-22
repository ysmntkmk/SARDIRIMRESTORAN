## Katmanlar

### NTier.Entities
Bu katman, projede kullan�lacak olan entity (varl�k) s�n�flar�n� i�erir. Entity s�n�flaru� genellikle veritaban�ndaki tablolar� temsil ederler. Bu anlamda her bir entity s�n�f�, veritaban�ndaki her bir tabloyu temsil etmektedir.

### NTier.DAL
Data Access Layer (veriye eri�im katman�) olarak adland�r�lan bu katman, veritaban�yla ileti�imden sorumludur. Vertiaban�na eri�im, sorgualr�n haz�rlanmas�, veri okuma/yazma gibi i�lemleri b�nyesinde ger�ekle�tirir.


### NTier.BLL
Business Logic Layer (�� Mant��� katman�) olarak adland�r�lan bu katman, uygulaman�n i� mant���n� i�erir. Kullan�c� taleplerini i�leyen ve veri eri�im katman� ile ileti�im kurmakla y�k�ml�d�r. Genellikle i� kurallar�n� ve i� s�re�lerini belirler.


### NTier.Common
Bu katman, projen,n farkl� katmanlar� aras�nda payla��mlar� i�eren genel katmand�r. �rne�in eposta g�nderimi, Ipadresi yakalama, g�rsel ekleme gibi i�lemler bu katman i�erisinde tan�mlan�r.

### NTier.IOC
Inversion Of Control projede kullan�lan ba��ml�l�klar�n dahil edilmesi veya bu ba��ml�l�klar�n ��z�mlenmesini ger�ekle�tiren katmand�r.