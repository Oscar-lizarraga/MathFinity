using System.ComponentModel.DataAnnotations;

namespace MathFinity.BOL;

public class Costumer
{


    public int costumerID { get; set; }

    [Required(ErrorMessage = "El campo {0} es necesario")]
    public string address { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es necesario")]
    [Phone(ErrorMessage = "El campo {0} debe ser un numero valido")]
    public string phone { get; set; } = null!;

    [Required(ErrorMessage = "El campo {0} es necesario")]
    public DateTime dateCreate { get; set; }


}
