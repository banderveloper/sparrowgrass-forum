using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SparrowgrassForum.Server.Domain;
using SparrowgrassForum.Server.Domain.Repositories;
using SparrowgrassForum.Server.Domain.Repositories.Abstract;
using SparrowgrassForum.Server.Domain.Repositories.EntityFramework;

namespace SparrowgrassForum.Server;

public class ServiceSetup
{
    private readonly WebApplicationBuilder _builder;

    public ServiceSetup(WebApplicationBuilder builder)
    {
        this._builder = builder;
    }

    public void Init()
    {
        _builder.Services.AddControllers().AddJsonOptions(options => {
            options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });

        _builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(_builder.Configuration.GetConnectionString("SqlServer"));
        });

        _builder.Services.AddScoped<IUserRepository, EfUserRepository>();
        _builder.Services.AddScoped<IEatRecordRepository, EfEatRecordRepository>();
        _builder.Services.AddScoped<DataManager>();
    }
}