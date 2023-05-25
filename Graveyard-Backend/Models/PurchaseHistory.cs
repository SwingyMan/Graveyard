using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class PurchaseHistory
{
    public PurchaseHistory()
    {
    }

    public PurchaseHistory(Customer customer, Cart cart)
    {
        this.customer = customer;
        this.cart = cart;
        date_of_purchase = DateOnly.FromDateTime(DateTime.Now);
    }
    [Key]
    public int ShopHistoryId { get; set; }
    public Customer customer { get; set; }
	public Cart cart { get; set; }
	public DateOnly date_of_purchase { get; set; }
    public PurchaseStatus Status { get; set; }
}
public enum PurchaseStatus { Done, Pending }