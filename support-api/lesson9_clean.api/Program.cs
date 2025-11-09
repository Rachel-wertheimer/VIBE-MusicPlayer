using clean.api.Middleweres;
using clean.core.Entities;
using clean.core.Repositories;
using clean.core;
using clean.data.Repositories;
using clean.data;
using clean.service.service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. הוספת מדיניות CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// 2. הוספת בקרות
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 3. תיעוד Swagger כולל JWT
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

// 4. הוספת JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

// 5. תלויות לפרויקטים פנימיים
builder.Services.AddScoped<IRepositorirsManager, ManagerRepositories>();
builder.Services.AddScoped<IRepository<Songs, int>, Repository<Songs, int>>();
builder.Services.AddScoped<IRepository<Singer, string>, Repository<Singer, string>>();
builder.Services.AddScoped<IRepository<Albums, int>, Repository<Albums, int>>();
builder.Services.AddScoped<AlbumsSrevice>();
builder.Services.AddScoped<SongService>();
builder.Services.AddScoped<SingerService>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// 6. הגדרות סביבתיות
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ?? קריטי: קודם CORS ? אחר כך Auth
app.UseCors("AllowAngularDevClient");

app.UseAuthentication();
app.UseAuthorization();

// ?? אפשר להשבית את המידלוור לזמן הבדיקה אם גורם לשגיאה 403
// app.UseMiddleware<SaturdayMidellewere>();

app.MapControllers();

app.Run();
