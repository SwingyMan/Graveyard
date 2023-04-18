using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Graveyard.Models;

public class Item
{
    public Item(string kind, decimal price, int quantity)
    {
        this.kind = kind;
        this.price = price;
        this.quantity = quantity;
    }

    [Key] public int ItemID { get; set; }

    public string kind { get; set; }
    public decimal price { get; set; }
    public int quantity { get; set; }
    public shopHistory shopHistory { get; set; } = null!;
    public Cart cart { get; set; } = null!;
}

public class Cart
{
    public Cart(Customer customer, Item items)
    {
        Customer = customer;
        Items.Add(items);
    }

    public Cart()
    {
    }
    
    public int CartId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<Item> Items { get; } = new List<Item>();
}

public class shopHistory
{
    public shopHistory()
    {
    }

    public shopHistory(Customer customer, List<Item> items)
    {
        this.customer = customer;
        Items = items;
        date_of_purchase = DateOnly.FromDateTime(DateTime.Now);
    }
    public int shopHistoryID { get; set; }
    public Customer customer { get; set; }
    public DateOnly date_of_purchase { get; set; }
    public ICollection<Item> Items { get; set; }
}