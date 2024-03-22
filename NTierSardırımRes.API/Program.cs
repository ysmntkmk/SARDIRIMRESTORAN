using Microsoft.EntityFrameworkCore;
using NTierSardırımRes.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Servislerin eklenmesi
builder.Services.AddControllers();

// Veritabanı bağlantısının eklenmesi
builder.Services.AddDbContext<SardirimContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS politikasının eklenmesi
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder
            .WithOrigins("https://localhost:7147")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Swagger ve API Dokümantasyonu ekleme
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// HTTP isteklerinin yönlendirilmesi
app.UseHttpsRedirection();

// CORS politikasının uygulanması
app.UseCors("MyCorsPolicy");

// Routing kullanımı
app.UseRouting();

// Endpoint konfigürasyonu
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseAuthorization();

app.Run();
