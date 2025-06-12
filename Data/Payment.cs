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




    //Functionality


    //Updates the payment fields to log a transaction
    public void RecordPayment()
    {
        PaymentDate = DateTime.Now;
        ReceiptNumber = GenerateReceiptNumber();
        CoverageEndDate = CoverageStartDate.AddMonths(PeriodMonths);
    }


    //Produces text output of a receipt
    // TODO: could change this to DTO mapping?
    public string GenerateReceipt()
    {
        return $"Receipt #{ReceiptNumber}\n" +
               $"Member: {Member.FirstName+" "+Member.LastName}\n" +
               $"Amount: ${Amount:F2}\n" +
               $"Method: {PaymentMethod}\n" +
               $"Period: {CoverageStartDate:dd/MM/yyyy} - {CoverageEndDate:dd/MM/yyyy}\n" +
               $"Date: {PaymentDate:dd/MM/yyyy}";
    }


    //Check if member has active roles that exempt from payment
    public bool ValidatePaymentRequired()
    {
        
        var exemptRoles = Member
            .GetActiveRoles()
            .Any(mr => mr.Role.RoleType == RoleType.Honorary ||
                       mr.Role.RoleType == RoleType.Professional);

        return !exemptRoles;
    }


    //Caclculate fees payable
    public decimal CalculateAmountDue()
    {
        if (!ValidatePaymentRequired())
            return 0;

        // base annual fee (?? configurable)
        decimal annualFee = 120.00m;
        return (annualFee / 12) * PeriodMonths;
    }


    //Generate a unique receipt number for the payment based on company formatting
    private string GenerateReceiptNumber()
    {
        return $"SL{DateTime.Now:yyyyMMdd}{this.Id:D4}";
    }
}

public enum PaymentMethod
{
    Cash = 1,
    Eft = 2,
    Cheque = 3,
    CreditCard = 4
}