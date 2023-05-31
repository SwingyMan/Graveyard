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
        this.customer = customer;
        this.cart = cart;
        date_of_purchase = DateOnly.FromDateTime(DateTime.Now);
        Status = PurchaseStatus.Pending;
    }

    [Key] public int ShopHistoryId { get; set; }

    public int CustomerId { get; set; }
    public Customer customer { get; set; }
    public List<Cart> cart { get; set; }
    public DateOnly date_of_purchase { get; set; }
    public PurchaseStatus Status { get; set; }
    public decimal TotalPrice { get; set; }
}

public enum PurchaseStatus
{
    Done,
    Pending
}