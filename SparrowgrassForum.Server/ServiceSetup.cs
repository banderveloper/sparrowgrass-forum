using System.Text.Json;
using System.Threading.RateLimiting;
using Microsoft.EntityFrameworkCore;
using SparrowgrassForum.Server.Domain;
using SparrowgrassForum.Server.Domain.Repositories;
using SparrowgrassForum.Server.Domain.Repositories.Abstract;
using SparrowgrassForum.Server.Domain.Repositories.EntityFramework;

namespace SparrowgrassForum.Server;

// Services injection class
public class ServiceSetup
{
    private readonly WebApplicationBuilder _builder;
    private const int RequestsPerMinute = 40;  // for limiting
    
    public ServiceSetup(WebApplicationBuilder builder)
    {
        this._builder = builder;
    }

    public void Init()
    {
        // JSON format to camelCase
        _builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });

        // ef sqlserver
        _builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(_builder.Configuration.GetConnectionString("SqlServer"));
        });

        // request per minute limit, otherwise 503
        _builder.Services.AddRateLimiter(options =>
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                    factory: partition => new FixedWindowRateLimiterOptions
                    {
                        AutoReplenishment = true,
                        PermitLimit = RequestsPerMinute,
                        QueueLimit = 0,
                        Window = TimeSpan.FromMinutes(1),
                    }));
        });

        
        _builder.Services.AddScoped<IUserRepository, EfUserRepository>();
        _builder.Services.AddScoped<IEatRecordRepository, EfEatRecordRepository>();
        _builder.Services.AddScoped<DataManager>();
    }
}