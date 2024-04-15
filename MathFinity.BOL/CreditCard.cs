namespace MathFinity.BOL;

public class CreditCard
{
    
    
    
    public string cardNumber { get; set; } = null!;
    
    public DateTime closingDate { get; set; }

    public float balance { get; set; }

    public DateTime issueDate { get; set; }

    public DateTime expiryDate { get; set; }

    public DateTime dueDate { get; set; }   

    public float creditLimit { get; set; }

    


}
