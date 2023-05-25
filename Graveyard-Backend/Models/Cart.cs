using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class Cart
{


    [Key]
    public int CartId { get; set; }
    public int CustomerId { get; set; }
    public int ItemId { get; set; }
    public Customer Customer { get; set; }
    public Item Items { get; set; }
    public Grave Grave { get; set; }

    public Cart()
	{
	}
	public Cart(Customer customer, Item items)
	{
		Customer = customer;
		Items = items;
	}
}