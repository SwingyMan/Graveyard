using System.ComponentModel.DataAnnotations;

namespace Graveyard.Models;

public class Grave
{
    private Grave()
    {
    }

    public Grave(int x, int y, string status, Burried burried, DateTime validUntil)
    {
        this.x = x;
        this.y = y;
        this.status = status;
        this.burried = burried;
        this.validUntil = validUntil;
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

    public Burried(string name, string lastname, DateTime dateOfBirth, DateTime dateOfDeath)
    {
        this.name = name;
        this.lastname = lastname;
        date_of_birth = dateOfBirth;
        date_of_death = dateOfDeath;
    }

    [Key] public int BurriedID { get; set; }

    public string name { get; set; }
    public string lastname { get; set; }
    public DateTime date_of_birth { get; set; }
    public DateTime date_of_death { get; set; }
}

public class ToBeBurried
{
    private ToBeBurried()
    {
    }
    [Key]
    public int ToBeBurriedID { get; set; }
    public DateTime burial_date { get; set; }
    public Burried burried { get; set; }
    
    public ToBeBurried(Burried burried, DateTime burialDate)
    {
        this.burried = burried;
        this.burial_date = burialDate;
    }
}