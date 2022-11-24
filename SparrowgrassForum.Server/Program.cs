using Microsoft.EntityFrameworkCore;
using SparrowgrassForum.Server.Domain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});



var app = builder.Build();
app.MapControllers();


app.Run();