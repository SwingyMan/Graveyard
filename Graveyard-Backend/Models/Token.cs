namespace Graveyard_Backend.Models;

public class Token
{
    public string Bearer { get; set; }

    public Token(string token)
    {
        Bearer = token;
    }
}