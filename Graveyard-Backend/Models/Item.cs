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
    public class ShoppingHistory
    {
        public Customer customer { get; set; }
        public Item Shop { get; set; }
        public int quantity { get; set; }
        public DateTime date_of_sell { get; set; }
    }
    [Keyless]
    public class ShoppingList
    {
        public int quantity { get; set; }
        public string status { get; set; }
        public DateTime date_of_sell { get; set; }
        public Customer customer { get; set; }
        public Item shop { get; set; }
    }
    public class Cart
    {
        public Customer Customer { get; set; }
        public List<Item> Items { get; set; }
        public Cart(Customer customer, Item items)
        {
            Customer = customer;
            Items.Add(items);
        }
    }
}
