using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class GraveBurried
{
    public GraveBurried()
    {
    }

    public GraveBurried(Burried burried, Grave grave,Gravedigger gravedigger, DateTime burialDate)
    {
        this.burried = burried;
        this.grave = grave;
        this.Gravedigger = gravedigger;
        this.burialDate = burialDate;
    }

    [Key] public int BurriedGraveId { get; set; }

    public Burried burried { get; set; }
    public Grave grave { get; set; }
    public Gravedigger Gravedigger { get; set; }
    public DateTime burialDate { get; set; }
}