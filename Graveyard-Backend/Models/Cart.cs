using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class Cart
{
    public Cart()
    {
    }

    public Cart(Customer customer, Item items, Grave grave, int quantity)
    {
        Customer = customer;
        Items = items;
        Grave = grave;
        Quantity = quantity;
    }


    [Key] public int CartId { get; set; }

    public int CustomerId { get; set; }
    public int ItemId { get; set; }
    public int GraveId { get; set; }
    public int Quantity { get; set; }
    public int? PurchaseHistoryShopHistoryId { get; set; }
    public Customer Customer { get; set; }
    public Item Items { get; set; }
    public Grave Grave { get; set; }
}