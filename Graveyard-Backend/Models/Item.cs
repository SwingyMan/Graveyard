using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class Item
{
	public Item(Kind kind, decimal price, int quantity)
	{
		Kind = kind;
		Price = price;
		Quantity = quantity;
	}

	[Key] 
	public int ItemId { get; set; }
	public Kind Kind { get; set; }
	public decimal Price { get; set; }
	public int Quantity { get; set; }
	public List<Cart> Carts { get; set; }
}
public enum Kind
{
	Service,
	Candle,
	Bloom
}