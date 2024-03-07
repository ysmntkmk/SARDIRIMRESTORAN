using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using NTierSard�r�mRes.BLL.Abstracts;
using NTierSard�r�mRes.DAL.Context;
using NTierSard�r�mRes.IOC.DependencyResolvers;
using NTierSard�r�mRes.MVC.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentityServices();
builder.Services.AddDbContextService();
builder.Services.AddRepositoryService();
MapperConfiguration mapperConfiguration = new MapperConfiguration(opt =>
{
    opt.AddProfile(new ProductProfile());
});
IMapper mapper = mapperConfiguration.CreateMapper();

builder.Services.AddSingleton<IMapper>(mapper);


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
    //Buraya custom route tan�mlanacak. �rne�in �r�n detaylar� g�sterilirken url'de olabild�ince seo'a uygun bir route olu�turulacak.


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
