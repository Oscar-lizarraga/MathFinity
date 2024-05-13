namespace MathFinity.BOL;

public class CreditCard
{
    
    public string accountNumber { get; set; } = null!;
    
    public string cardNumber { get; set; } = null!;
    
    public DateTime closingDate { get; set; }

    public float balance { get; set; }

    public DateTime issueDate { get; set; }

    public DateTime expireDate { get; set; }

    public DateTime dueDate { get; set; }   

    public float creditLimit { get; set; }

    public string CVV { get; set; } = null!;

    public string NIP { get; set; } = null!;

    


}
