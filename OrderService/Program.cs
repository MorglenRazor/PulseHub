using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderService.Data;
using Shared;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var orderConnectionString = builder.Configuration.GetConnectionString("OrderDb");

builder.Services.Configure<JwtSettings>(jwtSettings);
builder.Services.AddDbContext<OrderDbContext>(o => o.UseNpgsql(orderConnectionString));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!)),
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Run();
