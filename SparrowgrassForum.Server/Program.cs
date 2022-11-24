using Microsoft.EntityFrameworkCore;
using SparrowgrassForum.Server.Domain;
using SparrowgrassForum.Server.Domain.Repositories;
using SparrowgrassForum.Server.Domain.Repositories.Abstract;
using SparrowgrassForum.Server.Domain.Repositories.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IEatRecordRepository, EfEatRecordRepository>();
builder.Services.AddScoped<DataManager>();

var app = builder.Build();
app.MapControllers();

app.Run();