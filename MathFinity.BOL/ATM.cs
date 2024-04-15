using System.ComponentModel.DataAnnotations;

namespace MathFinity.BOL;

public class ATM
{
    public int ATMID { get; set; }

    [Required(ErrorMessage = "El campo {0} es necesario")]
    public float cashInBox { get; set; }
}
