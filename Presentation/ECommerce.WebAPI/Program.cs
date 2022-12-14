using System.Security.Claims;
using System.Text;
using ECommerce.Application;
using ECommerce.Application.Validators.Products;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.Filters;
using ECommerce.Infrastructure.Services.Storage.Azure;
using ECommerce.Persistance;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
//IOC Container
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4401", "https://localhost:4401", "http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

//IOCler
builder.Services.AddPersistanceServices(builder.Configuration);
//AddPersistanceServices taraf�m�zdan extension metot olarak persistance katman� alt�nda yaz�ld�. Buradaki ama� api katman�nda istedi�imiz bir servisi �a��rarak kullanmak-
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

//builder.Services.Add(StorageType.Azure);
//builder.Services.AddStorage(ECommerce.Infrastructure.Enums.StorageType.Local); // bu �ekilde de mimari ne ile �al��acaksa storage olarak onu enum �zerinden se�ebiliriz.
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();


builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options=> options.SuppressModelStateInvalidFilter = true);
//burada fluent val. ile gelen iste�in bizim tuttu�umuz rule lara uygun olup olmad���na bakarak cliente bilgi verir. Validation application katman�nda oldu�undan oradaki herhani bir validators class vermemiz yeterli olacakt�r. di�er validator class lar� vermemize gerek yoktur. tan�r.
//Validation Filter (infrastruxter katman�ndan devreye giriyor ki her gelen istek o filtreden ge�sin. handle olsun.)



builder.Services.AddEndpointsApiExplorer();

//swagger ayarlar�n� buradan config ediyoruz
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Token aliyim :)",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
//builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, //Oluþturulacak token deðerini kimlerin/hangi originlerin/sitelerin kullanýcý belirlediðimiz deðerdir. -> www.bilmemne.com
            ValidateIssuer = true, //Oluþturulacak token deðerini kimin daðýttýný ifade edeceðimiz alandýr. -> www.myapi.com
            ValidateLifetime = true, //Oluþturulan token deðerinin süresini kontrol edecek olan doðrulamadýr.
            ValidateIssuerSigningKey = true, //Üretilecek token deðerinin uygulamamýza ait bir deðer olduðunu ifade eden suciry key verisinin doðrulanmasýdýr.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

            // NameClaimType = ClaimTypes.Name //JWT üzerinde Name claimne karþýlýk gelen deðeri User.Identity.Name propertysinden elde edebiliriz.
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();

app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
