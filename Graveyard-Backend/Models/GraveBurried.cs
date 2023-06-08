using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class GraveBurried
{
    public GraveBurried()
    {
    }

    public GraveBurried(Burried burried, Grave grave, Gravedigger gravedigger, DateTime burialDate)
    {
        this.Burried = burried;
        this.Grave = grave;
        Gravedigger = gravedigger;
        this.BurialDate = burialDate;
    }

    [Key] public int BurriedGraveId { get; set; }

    public Burried Burried { get; set; }
    public Grave Grave { get; set; }
    public Gravedigger Gravedigger { get; set; }
    public DateTime BurialDate { get; set; }
}