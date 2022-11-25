using SparrowgrassForum.Server;

var builder = WebApplication.CreateBuilder(args);
new ServiceSetup(builder).Init(); // service injecting

var app = builder.Build();

app.UseRateLimiter(); // requests per minute limit
app.MapControllers();

app.Run();