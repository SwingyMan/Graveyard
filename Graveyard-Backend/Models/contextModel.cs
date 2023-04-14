using Microsoft.EntityFrameworkCore;

namespace Graveyard.Models
{
    public class contextModel : DbContext
    {
        public DbSet<Grave> grave { get; set; }
        public DbSet<ToBeBurried> burials { get; set; }
        public DbSet<Burried> burried { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Item> shop { get; set; }
        public DbSet<Cart> carts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=petition.postgres.database.azure.com;Database=graveyard;Username=petition;Password=VTEX8K8HV6t3egT ");
    }
}
