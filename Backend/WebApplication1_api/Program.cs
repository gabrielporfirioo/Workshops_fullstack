using Microsoft.EntityFrameworkCore;
using WebApplication1_api.Data;
using DotNetEnv;

Env.Load();
var connectingString = Environment.GetEnvironmentVariable("DB_CONECTING_STRING");




var builder = WebApplication.CreateBuilder(args);

// Confguração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configuração dos controladores
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexão com Banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectingString,
        new MySqlServerVersion(new Version(8, 0, 34)) // Substitua pela versão exata do seu MySQL
    )
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Permitir a conexão com o Angular
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});




builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
