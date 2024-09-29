using FridgeBE.Api;
using FridgeBE.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseStartup<Startup>();
builder.WebHost.ConfigureKestrel((context, serverOptions) => 
{
    serverOptions.ConfigureEndpoints();
});

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