using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace Graveyard.Models;

public class contextModel : DbContext
{
    private static ILogger _logger;

    public contextModel(DbContextOptions options, ILogger log) : base(options)
    {
        _logger = log;
    }

    public contextModel()
    {
    }

    public DbSet<Grave> grave { get; set; }
    public DbSet<ToBeBurried> burials { get; set; }
    public DbSet<Burried> burried { get; set; }
    public DbSet<Customer> customer { get; set; }
    public DbSet<Item> shop { get; set; }
    public DbSet<Cart> carts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("GraveyardDatabase"))
            .LogTo(_logger.Information, LogLevel.Information);
    }
}