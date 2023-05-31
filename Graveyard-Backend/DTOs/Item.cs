using Graveyard_Backend.Models;

namespace Graveyard_Backend.DTOs;

public class Item
{
    public string name { get; set; }
    public string description { get; set; }
    public string imageUrl { get; set; }
    public decimal price { get; set; }
    public int quantity { get; set; }
    public Kind kind { get; set; }
}