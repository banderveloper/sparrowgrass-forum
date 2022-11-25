using SparrowgrassForum.Server;

var builder = WebApplication.CreateBuilder(args);
new ServiceSetup(builder).Init();

var app = builder.Build();
app.MapControllers();

app.Run();