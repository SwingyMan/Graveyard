using Microsoft.EntityFrameworkCore;
using Serilog.Core;
using ILogger = Serilog.ILogger;

namespace Graveyard.Models;

public class contextModel : DbContext
{
    private static ILogger _logger;
    public DbSet<Grave> grave { get; set; }
    public DbSet<ToBeBurried> burials { get; set; }
    public DbSet<Burried> burried { get; set; }
    public DbSet<Customer> customer { get; set; }
    public DbSet<Item> shop { get; set; }
    public DbSet<Cart> carts { get; set; }
    public contextModel(DbContextOptions options,ILogger log):base(options){
        _logger = log;
    }
    public contextModel() { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=petition.postgres.database.azure.com;Database=graveyard;Username=petition;Password=VTEX8K8HV6t3egT ").LogTo(_logger.Information,LogLevel.Information);
    }
}