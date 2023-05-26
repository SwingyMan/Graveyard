using System.ComponentModel.DataAnnotations;
using Graveyard_Backend.DTOs;

namespace Graveyard_Backend.Models;

public class GraveBurried
{
    public GraveBurried(){}
    [Key]
    public int BurriedGraveId { get; set; }
    public Burried burried { get; set; }
    public Grave grave { get; set; }

    public GraveBurried(Burried burried, Grave grave)
    {
        this.burried = burried;
        this.grave =grave;
    }
}