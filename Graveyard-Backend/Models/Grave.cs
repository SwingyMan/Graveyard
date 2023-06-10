using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class Grave
{
    public Grave()
    {
    }

    public Grave(int x, int y)
    {
        this.x = x;
        this.y = y;
        Status = GraveStatus.Paid;
        ValidUntil = DateTime.Now.AddYears(5);
    }

    [Key] public int GraveId { get; set; }

    public int x { get; set; }
    public int y { get; set; }
    public GraveStatus Status { get; set; }
    public DateTime ValidUntil { get; set; }
}

public enum GraveStatus
{
    Unpaid,
    Paid
}