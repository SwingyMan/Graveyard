using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class PurchaseHistory
{
    public PurchaseHistory()
    {
    }

    public PurchaseHistory(Customer customer, List<Cart> cart, decimal totalPrice)
    {
        TotalPrice = totalPrice;
        this.Customer = customer;
        this.Cart = cart;
        Date_of_purchase = DateOnly.FromDateTime(DateTime.Now);
        Status = PurchaseStatus.Pending;
    }

    [Key] public int ShopHistoryId { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<Cart> Cart { get; set; }
    public DateOnly Date_of_purchase { get; set; }
    public PurchaseStatus Status { get; set; }
    public decimal TotalPrice { get; set; }
}

public enum PurchaseStatus
{
    Done,
    Pending
}