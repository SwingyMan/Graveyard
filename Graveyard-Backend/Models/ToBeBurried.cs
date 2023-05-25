using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class ToBeBurried
{
    public ToBeBurried()
    {
    }

    public ToBeBurried(Burried burried, DateTime burialDate)
    {
        this.burried = burried;
        burial_date = burialDate;
    }

    [Key] public int ToBeBurriedId { get; set; }

    public DateTime burial_date { get; set; }
    public Burried burried { get; set; }
}