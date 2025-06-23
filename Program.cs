using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PocMissionPush.Infrastructure.Persistance;
using PocMissionPush.Subscriptions;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();
builder.Services.AddDbContext<SubscriptionDbContext>(opt => opt.UseInMemoryDatabase("SubscriptionList"));


builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<PushService>();
builder.Services.AddScoped<SubscriptionService>();

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = "https://auth.ade-dev.fr/realms/ustest";
    options.RequireHttpsMetadata = true;
    // options.Audience = "us-mecanic";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidAudiences = new[] {
            "mecanic-api",
            "us-client"
        }
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("customPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();



app.UseCors("customPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
