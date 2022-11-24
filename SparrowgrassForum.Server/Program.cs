using Microsoft.EntityFrameworkCore;
using SparrowgrassForum.Server.Domain;
using SparrowgrassForum.Server.Domain.Repositories.Abstract;
using SparrowgrassForum.Server.Domain.Repositories.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});

builder.Services.AddSingleton<IUserRepository, EfUserRepository>();
builder.Services.AddSingleton<IEatRecordRepository, EfEatRecordRepository>();

var app = builder.Build();
app.MapControllers();

app.Run();