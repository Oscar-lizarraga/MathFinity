using System.ComponentModel.DataAnnotations;

namespace MathFinity.BOL;

public class Customer
{


    public string customerID { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es necesario")]
    public int interestID { get; set; }

    public string address { get; set; } = null!;

    public string phone { get; set; } = null!;

    public DateTime dateCreate { get; set; }


}
