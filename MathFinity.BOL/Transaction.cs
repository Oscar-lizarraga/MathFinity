namespace MathFinity.BOL;

public class Transaction
{
    public string transactionNumber { get; set; } = null!;
    public float amount { get; set; }
    public bool approved { get; set; }
    public DateTime date { get; set; }
    public string accountNumber { get; set; } = null!;
    public Transfer transfer { get; set; } = null!;
    public WithDrawal withDrawal { get; set; } = null!;
}
