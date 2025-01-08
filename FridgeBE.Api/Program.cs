using FridgeBE.Api;


var builder = WebApplication.CreateBuilder(args);

// Kestrel Configuration
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(7160, listenOptions =>
//    {
//        listenOptions.UseHttps("/https/aspnetapp.pfx", "YourPassword");
//    });
//});
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5091); // HTTP
    options.ListenAnyIP(7160, listenOptions =>
    {
        Console.WriteLine($"Location in Docker {AppContext.BaseDirectory}"); // /app/ at final stage in Dockerfile
        listenOptions.UseHttps("https/localhost.pfx", "yourpassword");
    });
});

//builder.WebHost.UseUrls("http://localhost:5003", "https://localhost:5004");

//Console.WriteLine(typeof(Ingredient));
//MySqlConnection MyCon = new MySqlConnection(builder.Configuration.GetConnectionString("Fridge"));

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

Startup _startup = new Startup(builder.Configuration);

_startup.ConfigureServices(builder.Services);

var app = builder.Build();

// run migrations
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    await db.Database.MigrateAsync();
//}

_startup.Configure(app, app.Environment);

app.Run();