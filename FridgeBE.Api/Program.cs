using FridgeBE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MySqlConnector;
using System.Diagnostics;

//MySqlConnection MyCon = new MySqlConnection("Server=localhost;Port=57779;Database=fridge;Uid=root;Pwd=my-secret-pw;");

//try
//{
//    MyCon.Open();
//    Debug.WriteLine("aaaaaaaaaaaaaaaaa - Open");

//    MyCon.Close();
//    Debug.WriteLine("aaaaaaaaaaaaaaaaa - Close");
//}
//catch (Exception ex)
//{
//    Debug.WriteLine("aaaaaaaaaaaaaaaaa -");
//    Debug.WriteLine(ex.Message);
//}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddDbContextPool<ApplicationDbContext>(option =>
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseMySql(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Fridge")), sqlOptionsBuilder =>
    {
        //sqlOptionsBuilder.EnableRetryOnFailure();
        //sqlOptionsBuilder.MigrationsAssembly("FridgeBE.Infrastructure");
    });
    option.UseLoggerFactory(LoggerFactory.Create(configure => configure.AddConsole()));
    option.LogTo(Console.WriteLine, LogLevel.Debug, DbContextLoggerOptions.DefaultWithLocalTime);
    option.EnableSensitiveDataLogging();
    option.EnableDetailedErrors();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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