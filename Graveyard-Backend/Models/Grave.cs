using System.ComponentModel.DataAnnotations;

namespace Graveyard.Models;

public class Grave
{
    public Grave()
    {
    }

    public Grave(int x, int y, string status, Burried burried)
    {
        this.x = x;
        this.y = y;
        this.status = status;
        this.burried = burried;
        validUntil = DateTime.Now.AddYears(5);
    }

    [Key] public int GraveID { get; set; }

    public int x { get; set; }
    public int y { get; set; }
    public string status { get; set; }
    public Burried burried { get; set; }
    public DateTime validUntil { get; set; }
}

public class Burried
{
    public Burried()
    {
    }

    public Burried(string name, string lastname, DateOnly dateOfBirth, DateOnly dateOfDeath)
    {
        this.name = name;
        this.lastname = lastname;
        date_of_birth = dateOfBirth;
        date_of_death = dateOfDeath;
    }

    [Key] public int BurriedID { get; set; }

    public string name { get; set; }
    public string lastname { get; set; }
    public DateOnly date_of_birth { get; set; }
    public DateOnly date_of_death { get; set; }
}

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

    [Key] public int ToBeBurriedID { get; set; }

    public DateTime burial_date { get; set; }
    public Burried burried { get; set; }
}