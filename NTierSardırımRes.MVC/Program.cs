using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierSardýrýmRes.DAL.Context;
using NTierSardýrýmRes.Entities.Entities;
using NTierSardýrýmRes.IOC.DependencyResolvers;
using NTierSardýrýmRes.MVC.UIDependencyResolver;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Servislerin konteynýra eklenmesi
builder.Services.AddControllersWithViews(); // MVC hizmetlerini ekle
builder.Services.AddIdentityServicesAsync(); // Kimlik hizmetlerini ekle (Kullanýcý yönetimi)
builder.Services.AddDbContextService(); // Veritabaný baðlamýný ekle
builder.Services.AddRepositoryService(); // Repository hizmetlerini ekle
builder.Services.AddMapperService(); // AutoMapper hizmetlerini ekle



// ConfigureServices metodunun yapýlandýrýlmasý
builder.Services.AddAuthentication(options =>
{
    // Kimlik doðrulama þemalarýný yapýlandýr
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Kimlik doðrulama için varsayýlan þemayý ayarla
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Oturum açma için varsayýlan þemayý ayarla
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Zorlamalý kimlik doðrulama için varsayýlan þemayý ayarla
})
.AddCookie(options =>
{
    // Çerez seçeneklerini yapýlandýr
    options.Cookie.Name = "YourCookieName"; // Opsiyonel: Çerezin adýný belirleyebilirsiniz
    options.Cookie.HttpOnly = true; // Sadece HTTP protokolü aracýlýðýyla çerezlere eriþimi etkinleþtir
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturumun süresini ayarla
    options.LoginPath = "/Account/Login"; // Kullanýcý giriþi sayfasýnýn yolu
    options.AccessDeniedPath = "/Account/AccessDenied"; // Eriþim reddedildi sayfasýnýn yolu
    options.SlidingExpiration = true; // Oturum süresini her istekte sýfýrla
    options.LogoutPath = "/Account/Logout"; // Kullanýcý çýkýþ yaparken yönlendirilecek sayfa
   
});



var app = builder.Build();

// HTTP isteði boru hattýnýn yapýlandýrýlmasý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Hata durumlarýný iþle
    app.UseHsts(); // HTTP Strict Transport Security (HSTS) kullan
}

app.UseHttpsRedirection(); // HTTPS'e yönlendirme kullan
app.UseStaticFiles(); // Statik dosyalarý sun

app.UseRouting(); // Yönlendirmeyi etkinleþtir
app.UseAuthentication(); // Kimlik doðrulama kullan
app.UseAuthorization(); // Yetkilendirme kullan

app.UseEndpoints(endpoints =>
{
    // Admin Rota
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    // Varsayýlan Rota
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run(); // Uygulamayý baþlat
