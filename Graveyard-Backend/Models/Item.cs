using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Graveyard.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public string kind { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }

    }
    [Keyless]
    public class Cart
    {
        public Customer Customer { get; set; }
        public List<Item> Items { get; set; }
        public Cart(Customer customer, Item items)
        {
            Customer = customer;
            Items.Add(items);
        }
        public Cart() {}
    }
}
