using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace Graveyard_Backend.Models;

public class ContextModel : DbContext
{
    private static ILogger _logger;

    public ContextModel(DbContextOptions options, ILogger log) : base(options)
    {
        _logger = log;
    }

    public ContextModel()
    {
    }

    public DbSet<Customer> Customer { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<Grave> Grave { get; set; }

    public DbSet<Gravedigger> Gravediggers { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Burried> Burried { get; set; }
    public DbSet<GraveBurried> GraveBurried { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistory { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_GraveyardDatabase"))
            .LogTo(_logger.Information, LogLevel.Information);
    }
}