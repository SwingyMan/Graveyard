using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Graveyard.Models
{
    public class Shop
    {
        [Key]
        public int id_i { get; set; }
        public string kind { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }

    }
    [Keyless]
    public class ShoppingHistory
    {
        public Customer customer { get; set; }
        public Shop Shop { get; set; }
        public int quantity { get; set; }
        public DateTime date_of_sell { get; set; }
    }
    [Keyless]
    public class ShoppingList {
        public int quantity {get; set; }
        public string status { get; set; }
        public DateTime date_of_sell { get; set; }
        public Customer customer { get; set; }
        public Shop shop { get; set; }
    }
}
