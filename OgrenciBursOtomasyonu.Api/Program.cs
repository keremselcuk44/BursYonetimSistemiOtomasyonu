using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OgrenciBursOtomasyonu.Api;
using OgrenciBursOtomasyonu.Api.Data;
using OgrenciBursOtomasyonu.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Controller tabanlı API desteği
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // JSON property isimlerini case-insensitive yap (email, Email, EMAIL hepsi kabul edilir)
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

// Swagger / OpenAPI yapılandırması
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Öğrenci Burs Otomasyonu API",
        Version = "v1"
    });
});

// SQL Server Entity Framework Core yapılandırması
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repository'leri DI container'a ekle
builder.Services.AddScoped<OgrenciRepository>();
builder.Services.AddScoped<BursRepository>();
builder.Services.AddScoped<OgrenciBursRepository>();
builder.Services.AddScoped<BursOdemeTakipRepository>();
builder.Services.AddScoped<KullaniciRepository>();

// Gemini servisi için HttpClient + DI (timeout ve retry ayarları ile)
builder.Services.AddHttpClient<IGeminiPuanlamaService, GeminiPuanlamaService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(120); // 2 dakika timeout
});
builder.Services.AddHttpClient<IGeminiMailService, GeminiMailService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(120); // 2 dakika timeout
});

// Mail servisleri
builder.Services.AddScoped<IEmailService, EmailService>();

// Öğrenci servis katmanı
builder.Services.AddScoped<IOgrenciService, OgrenciService>();

// CORS yapılandırması
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// HTTP istek hattı
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Öğrenci Burs Otomasyonu API v1");
    });
    
    // Development ortamında detaylı hata sayfalarını göster
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

app.Run();
