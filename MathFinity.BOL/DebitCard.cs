namespace MathFinity.BOL;

public class DebitCard
{
    public string accountNumber { get; set; } = null!;
    public string cardNumber { get; set; } = null!;
    public float balance { get; set; }
    public DateTime issueDate { get; set; } 
    public DateTime expireDate { get; set; }
    public string CVV  { get; set; } = null!;
    public string NIP  { get; set; } = null!;
}
