using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class Item
{
	public Item(){}
	public Item(string name,string description,Kind kind, decimal price, int quantity,string imageUrl)
	{
		Name = name;
		Description = description;
		Kind = kind;
		Price = price;
		Quantity = quantity;
		ImageURL = imageUrl;
	}

	[Key] 
	public int ItemId { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public Kind Kind { get; set; }
	public decimal Price { get; set; }
	public int Quantity { get; set; }
	public string ImageURL { get; set; }
	public List<Cart> Carts { get; set; }
}
public enum Kind
{
	Service,
	Candle,
	Bloom
}