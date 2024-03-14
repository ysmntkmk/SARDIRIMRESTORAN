using Microsoft.AspNetCore.Identity;
using NTierSardırımRes.Common.EmailSender;
using NTierSardırımRes.DAL.Context;
using NTierSardırımRes.Entities.Entities;
using NTierSardırımRes.IOC.DependencyResolvers;
using NTierSardırımRes.MVC.UIDependencyResolver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServices();

builder.Services.AddDbContextService();
builder.Services.AddRepositoryService();

builder.Services.AddMapperService();

//Cookie
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = new PathString("/Home/Login");
    x.AccessDeniedPath = new PathString("/Home/DeniedPage");
    x.Cookie = new CookieBuilder
    {
        Name = "SardirimRestorant_Cookie"
    };
    x.SlidingExpiration = true;
    x.ExpireTimeSpan = TimeSpan.FromMinutes(5);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();



app.UseEndpoints(endpoint =>
{
    //Admin Route
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
    });


    //Custom Route
    //Buraya custom route tanımlanacak. Örneğin ürün detayları gösterilirken url'de olabildğince seo'a uygun bir route oluşturulacak.


    //Default Route

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    });


});




app.Run();
