using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierSard�r�mRes.DAL.Context;
using NTierSard�r�mRes.Entities.Entities;
using NTierSard�r�mRes.IOC.DependencyResolvers;
using NTierSard�r�mRes.MVC.UIDependencyResolver;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Servislerin konteyn�ra eklenmesi
builder.Services.AddControllersWithViews(); // MVC hizmetlerini ekle
builder.Services.AddIdentityServicesAsync(); // Kimlik hizmetlerini ekle (Kullan�c� y�netimi)
builder.Services.AddDbContextService(); // Veritaban� ba�lam�n� ekle
builder.Services.AddRepositoryService(); // Repository hizmetlerini ekle
builder.Services.AddMapperService(); // AutoMapper hizmetlerini ekle



// ConfigureServices metodunun yap�land�r�lmas�
builder.Services.AddAuthentication(options =>
{
    // Kimlik do�rulama �emalar�n� yap�land�r
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Kimlik do�rulama i�in varsay�lan �emay� ayarla
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Oturum a�ma i�in varsay�lan �emay� ayarla
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Zorlamal� kimlik do�rulama i�in varsay�lan �emay� ayarla
})
.AddCookie(options =>
{
    // �erez se�eneklerini yap�land�r
    options.Cookie.Name = "YourCookieName"; // Opsiyonel: �erezin ad�n� belirleyebilirsiniz
    options.Cookie.HttpOnly = true; // Sadece HTTP protokol� arac�l���yla �erezlere eri�imi etkinle�tir
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturumun s�resini ayarla
    options.LoginPath = "/Account/Login"; // Kullan�c� giri�i sayfas�n�n yolu
    options.AccessDeniedPath = "/Account/AccessDenied"; // Eri�im reddedildi sayfas�n�n yolu
    options.SlidingExpiration = true; // Oturum s�resini her istekte s�f�rla
    options.LogoutPath = "/Account/Logout"; // Kullan�c� ��k�� yaparken y�nlendirilecek sayfa
   
});



var app = builder.Build();

// HTTP iste�i boru hatt�n�n yap�land�r�lmas�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Hata durumlar�n� i�le
    app.UseHsts(); // HTTP Strict Transport Security (HSTS) kullan
}

app.UseHttpsRedirection(); // HTTPS'e y�nlendirme kullan
app.UseStaticFiles(); // Statik dosyalar� sun

app.UseRouting(); // Y�nlendirmeyi etkinle�tir
app.UseAuthentication(); // Kimlik do�rulama kullan
app.UseAuthorization(); // Yetkilendirme kullan

app.UseEndpoints(endpoints =>
{
    // Admin Rota
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    // Varsay�lan Rota
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run(); // Uygulamay� ba�lat
