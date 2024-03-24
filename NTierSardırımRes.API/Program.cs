

using NTierSardýrýmRes.IOC.DependencyResolvers;
using NTierSardýrýmRes.MVC.UIDependencyResolver;

var builder = WebApplication.CreateBuilder(args);


// Servislerin eklenmesi
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServices();

builder.Services.AddDbContextService();
//builder.Services.AddRepositoryService();

builder.Services.AddMapperService();


//CORS
builder.Services.AddCors(cors =>
{
    cors.AddPolicy("SardirimCors", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

RepositoryService.AddRepositoryService(builder.Services);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseCors("SardirimCors");

app.UseAuthorization();

app.MapControllers();

app.Run();


