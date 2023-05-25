using Graveyard_Backend.Models;

namespace Graveyard_Backend.DTOs;

public class Grave
{
    public int x { get; set; }
    public int y { get; set; }
    public GraveStatus status { get; set; }
    public string name { get; set; }
    public string lastname { get; set; }
    public DateOnly date_of_birth { get; set; }
    public DateOnly date_of_death { get; set; }
}