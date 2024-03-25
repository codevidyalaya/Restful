using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.Logging;
using Restful_API.MapperConfiguration;
using Restful_API.Repository.IRepository;
using Restful_API.Repository;

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
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers().AddNewtonsoftJson() ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILogging, Logging>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
