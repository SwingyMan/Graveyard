using Graveyard_Backend.Models;

namespace Graveyard_Backend.DTOs;

public class Item
{
    public decimal price { get; set; }
    public int quantity { get; set; }
    public Kind kind { get; set; }
}