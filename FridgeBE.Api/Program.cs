using FridgeBE.Api;


var builder = WebApplication.CreateBuilder(args);

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

_startup.Configure(app, app.Environment);

app.Run();