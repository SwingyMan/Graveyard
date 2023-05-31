namespace Graveyard_Backend.Models;

public class Gravedigger
{
    public Gravedigger()
    {
    }

    public Gravedigger(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public int GravediggerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}