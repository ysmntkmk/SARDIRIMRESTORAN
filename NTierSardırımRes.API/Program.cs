

var builder = WebApplication.CreateBuilder(args);


// Servislerin eklenmesi
builder.Services.AddControllers();


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


