namespace Graveyard_Backend.DTOs;

public class Burial
{
    public string name { get; set; }
    public string lastname { get; set; }
    public DateOnly date_of_birth { get; set; }
    public DateOnly date_of_death { get; set; }
    public DateTime burial_date { get; set; }
}