using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.Logging;
using Restful_API.MapperConfiguration;
using Restful_API.Repository.IRepository;
using Restful_API.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//    .WriteTo.File("Log/student.txt", rollingInterval: RollingInterval.Day).CreateLogger();

//builder.Host.UseSerilog();

// Add services to the container.
//builder.Logging.AddConsole();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddAutoMapper(typeof(StudentMappingConfig));
builder.Services.AddScoped<ILocalUserRepository, LocalUserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers().AddNewtonsoftJson() ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILogging, Logging>();

var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false; // Set to true if your production environment uses HTTPS
    x.SaveToken = true; // Whether to save the token as a claim
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, // Validate the token issuer
        ValidateAudience = false, // Validate the token audience
        ValidateLifetime = false, // Validate the token expiry
        ValidateIssuerSigningKey = true, // Validate the signing key

        // Set the values for your token validation
        ValidIssuer = "your_issuer", // The issuer of the token
        ValidAudience = "your_audience", // The audience of the token
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // The key used to sign the token
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "School", Version = "v1" });

    // Optionally, include additional information about your API
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "YourApiDocumentation.xml"));

    // Optionally, configure security definitions for your API endpoints
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
