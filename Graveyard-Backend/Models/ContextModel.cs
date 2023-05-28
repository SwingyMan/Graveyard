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

	public DbSet<Customer> customer { get; set; }
	public DbSet<Item> item { get; set; }
	public DbSet<Grave> grave { get; set; }
	public DbSet<ToBeBurried> burials { get; set; }
	public DbSet<Cart> carts { get; set; }
	public DbSet<Burried> burried { get; set; }
	public DbSet<GraveBurried> graveBurried { get; set; }
	public DbSet<PurchaseHistory> purchaseHistory { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
				optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_GraveyardDatabase"))
			.LogTo(_logger.Information, LogLevel.Information);
	}
}