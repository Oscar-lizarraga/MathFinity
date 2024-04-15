using System.ComponentModel.DataAnnotations;

namespace MathFinity.BOL;

public class Branch
{
    public int branhdID { get; set; }

    [Required(ErrorMessage = "El campo {0} es necesario")]
    public string address { get; set; } = null!;
    
}
