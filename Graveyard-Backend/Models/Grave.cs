using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class Grave
{
	public Grave()
	{
	}

	public Grave(int x, int y, GraveStatus status)
	{
		this.x = x;
		this.y = y;
		this.status = status;
		validUntil = DateTime.Now.AddYears(5);
	}

	[Key]
	public int GraveId { get; set; }
	public int x { get; set; }
	public int y { get; set; }
	public GraveStatus status { get; set; }
	public DateTime validUntil { get; set; }
	public List<BurriedGrave> BurriedGraves { get; set; }
	public List<Cart> Carts { get; set; }
}
public enum GraveStatus
{
	Unpaid,
	Paid
}