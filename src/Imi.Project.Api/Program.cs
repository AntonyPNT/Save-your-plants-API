using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Api.Repositories;
using Imi.Project.Api.Repositories.Interface;
using Imi.Project.Api.Services.Images;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Imi.Project.Api.Core.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services;
using Microsoft.OpenApi.Models;
//using Imi.Project.Api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5000", "https://0.0.0.0:5001");

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));

//hier instellen
builder.Services.AddDefaultIdentity<ApplicationUser>
    (options =>
    {
        options.SignIn.RequireConfirmedAccount = false; 
        options.Password.RequiredLength = 4;
        options.Password.RequireUppercase = true;
        options.Password.RequireDigit = true;
        options.Password.RequiredUniqueChars = 1;

    }).AddEntityFrameworkStores<ApplicationDBContext>();


//add authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateActor = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["JWTConfiguration:Issuer"],
            ValidAudience = builder.Configuration["JWTConfiguration:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration["JWTConfiguration:SigninKey"]))
        };
    }); 

//add authorization policies
builder.Services.AddAuthorization(options =>
{
    //admin only
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "admin");
    });

    //must be admin or user
    options.AddPolicy("User", policy =>
    {
        policy.RequireAssertion(context =>
        {
            if (context.User.HasClaim(ClaimTypes.Role, "admin")
            || context.User.HasClaim(ClaimTypes.Role, "user"))
            {
                return true;
            }
            return false;
        });
    });
});

builder.Services.AddCors();

builder.Services.AddScoped<IPlantRepository, PlantRepository>();
builder.Services.AddScoped<IPlantActionRepository, PlantActionRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//source
//"https://www.thecodebuzz.com/jwt-authorization-token-swagger-open-api-asp-net-core-3-0/"

builder.Services.AddSwaggerGen(c =>
{

    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "bearerAuth"
                                }
                            },
                            new string[] {}
                    }
                });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
}

app.UseHttpsRedirection();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();

app.Run();