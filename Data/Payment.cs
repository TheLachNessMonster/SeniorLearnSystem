namespace SeniorLearnSystem.Data;

public class Payment
{
    public int Id { get; set; }
    
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }
    public int PeriodMonths { get; set; }
    public DateTime CoverageStartDate { get; set; }
    public DateTime CoverageEndDate { get; set; }
    public string ReceiptNumber { get; set; } = string.Empty;

    // nav properties
    public int MemberId { get; set; }
    public virtual Member Member { get; set; } = null!;

}

public enum PaymentMethod
{
    Cash = 1,
    Eft = 2,
    Cheque = 3,
    CreditCard = 4
}