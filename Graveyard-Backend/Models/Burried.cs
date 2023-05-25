using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

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

    [Key] public int BurriedId { get; set; }

    public string name { get; set; }
    public string lastname { get; set; }
    public DateOnly date_of_birth { get; set; }
    public DateOnly date_of_death { get; set; }
    public List<BurriedGrave> BurriedGraves { get; set; }
}