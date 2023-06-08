using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class Grave
{
    public Grave()
    {
    }

    public Grave(int x, int y)
    {
        this.X = x;
        this.Y = y;
        Status = GraveStatus.Paid;
        ValidUntil = DateTime.Now.AddYears(5);
    }

    [Key] public int GraveId { get; set; }

    public int X { get; set; }
    public int Y { get; set; }
    public GraveStatus Status { get; set; }
    public DateTime ValidUntil { get; set; }
    public List<GraveBurried> BurriedGraves { get; set; }
}

public enum GraveStatus
{
    Unpaid,
    Paid
}