using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graveyard.Models
{
    public class contextModel : DbContext
    {
        public DbSet<Grave> grave { get; set; }
        public DbSet<ToBeBurried> burials { get; set; }
        public DbSet<Burried> burried { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Shop> shop { get; set; }
        public DbSet<ShoppingHistory> shopHistory { get; set; }
        public DbSet<ShoppingList> shopList { get; set; }
        public DbSet<OwnedGrave> ownedGraves { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=localhost;Database=graveyard;Username=postgres;Password=123");
    }
}
