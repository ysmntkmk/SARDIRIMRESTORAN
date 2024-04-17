using NTierSard�r�mRes.IOC.DependencyResolvers;
using NTierSard�r�mRes.MVC.UIDependencyResolver;

var builder = WebApplication.CreateBuilder(args);

// Servislerin eklenmesi
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServicesAsync();
builder.Services.AddDbContextService();
builder.Services.AddMapperService();
RepositoryService.AddRepositoryService(builder.Services);

// CORS
builder.Services.AddCors(cors =>
{
    cors.AddPolicy("SardirimCors", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

// Swagger/OpenAPI
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

// HTTP iste�i i�leme boru hatt�n�n yap�land�r�lmas�
app.UseHttpsRedirection();
app.UseCors("SardirimCors");
app.UseAuthorization();
app.MapControllers();
app.Run();



