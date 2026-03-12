

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RESTfulAPIJWT.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Modify To Include Bearer JWT Token Input Dialog In Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Standard Authorizaton header using the Bearer scheme (\"bearer {token}\")",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey

    });

    // Add To Include Bearer JWT Token In Swagger
    options.OperationFilter<SecurityRequirementsOperationFilter>();

});

// Added to Require JWT Bearer Token for Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:TokenSecretKey").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false,   
        };
    });


// Add Service to IOC Container for Dependency Injection 
builder.Services.AddScoped<IService, Service>();


// Conifgure CORS Settings

builder.Services.AddCors(options =>
            {
            // Configure SpecificOriginsPolicy
            var specificOriginsSection = builder.Configuration.GetSection("CorsSettings:SpecificOriginsPolicy");
            if (specificOriginsSection.Exists())
            {
                var allowedOrigins = specificOriginsSection["AllowedOrigins"]?.Split(';', StringSplitOptions.RemoveEmptyEntries);
                var allowedHeaders = specificOriginsSection["AllowedHeaders"]?.Split(';', StringSplitOptions.RemoveEmptyEntries);
                var allowedMethods = specificOriginsSection["AllowedMethods"]?.Split(';', StringSplitOptions.RemoveEmptyEntries);
                var allowCredentials = specificOriginsSection.GetValue<bool>("AllowCredentials");

                options.AddPolicy("SpecificOriginsPolicy", policy =>
                {
                    if (allowedOrigins != null && allowedOrigins.Length > 0)
                    {
                        policy.WithOrigins(allowedOrigins);
                    }
                    if (allowedHeaders != null && allowedHeaders.Length > 0)
                    {
                        policy.WithHeaders(allowedHeaders);
                    }
                    if (allowedMethods != null && allowedMethods.Length > 0)
                    {
                        policy.WithMethods(allowedMethods);
                    }
                    if (allowCredentials)
                    {
                        policy.AllowCredentials();
                    }
                });
            }

                // Configure AnyOriginPolicy (if needed)
                /*
                var anyOriginSection = builder.Configuration.GetSection("CorsSettings:AnyOriginPolicy");
                if (anyOriginSection.Exists() && anyOriginSection.GetValue<bool>("AllowAnyOrigin"))
                {
                    options.AddPolicy("AnyOriginPolicy", policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
                }
                */

            });


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();


// Added 
app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
