using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class Burried
{
    public Burried()
    {
    }

    public Burried(string name, string lastname, DateOnly dateOfBirth, DateOnly dateOfDeath)
    {
        this.Name = name;
        this.Lastname = lastname;
        Date_of_birth = dateOfBirth;
        Date_of_death = dateOfDeath;
    }

    [Key] public int BurriedId { get; set; }

    public string Name { get; set; }
    public string Lastname { get; set; }
    public DateOnly Date_of_birth { get; set; }
    public DateOnly Date_of_death { get; set; }
}