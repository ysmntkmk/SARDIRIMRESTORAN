using Microsoft.EntityFrameworkCore;
using NTierSard�r�mRes.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Servislerin eklenmesi
builder.Services.AddControllers();

// Veritaban� ba�lant�s�n�n eklenmesi
builder.Services.AddDbContext<SardirimContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS politikas�n�n eklenmesi
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

// Swagger ve API Dok�mantasyonu ekleme
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// HTTP isteklerinin y�nlendirilmesi
app.UseHttpsRedirection();

// CORS politikas�n�n uygulanmas�
app.UseCors("MyCorsPolicy");

// Routing kullan�m�
app.UseRouting();

// Endpoint konfig�rasyonu
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseAuthorization();

app.Run();
