using System.ComponentModel.DataAnnotations;

namespace MathFinity.BOL;

public class Prospect
{
    public int prospectID { get; set; }

    [Range(0,100, ErrorMessage = "El campo {0} solo puede tomar valores des de {1} hasta {2}")]
    [Required(ErrorMessage = "El campo {0} es necesario")]
    public float age { get; set; }

    [Range(0,1, ErrorMessage = "El campo {0} solo puede tomar valores des de {1} hasta {2}")]
    [Required(ErrorMessage = "El campo {0} es necesario")]
    public int gender { get; set; }


    [Range(0,1, ErrorMessage = "El campo {0} solo puede tomar valores des de {1} hasta {2}")]
    [Required(ErrorMessage = "El campo {0} es necesario")]
    public int married { get; set; }


    [Range(0,1, ErrorMessage = "El campo {0} solo puede tomar valores des de {1} hasta {2}")]
    [Required(ErrorMessage = "El campo {0} es necesario")]
    public int driversLicense { get; set; }


    [Range(0,1, ErrorMessage = "El campo {0} solo puede tomar valores des de {1} hasta {2}")]
    [Required(ErrorMessage = "El campo {0} es necesario")]
    public int employed { get; set; }



    [Required(ErrorMessage = "El campo {0} es necesario")]
    public string zipCode { get; set; } = null!;


    [Range(0,1, ErrorMessage = "El campo {0} solo puede tomar valores des de {1} hasta {2}")]
    [Required(ErrorMessage = "El campo {0} es necesario")]
    public float debt { get; set; }


    [Range(0,1, ErrorMessage = "El campo {0} solo puede tomar valores des de {1} hasta {2}")]
    [Required(ErrorMessage = "El campo {0} es necesario")]
    public int bankCustomer { get; set; }



    [Required(ErrorMessage = "El campo {0} es necesario")]
    public string industry { get; set; } = null!;



    [Required(ErrorMessage = "El campo {0} es necesario")]
    public string Ethnicity { get; set; } = null!;


    [Range(0,100, ErrorMessage = "El campo {0} solo puede tomar valores des de {1} hasta {2}")]
    [Required(ErrorMessage = "El campo {0} es necesario")]
    public float yearsEmployed { get; set; }


    [Range(0,1, ErrorMessage = "El campo {0} solo puede tomar valores des de {1} hasta {2}")]
    [Required(ErrorMessage = "El campo {0} es necesario")]
    public int priorDefault { get; set; }



    [Required(ErrorMessage = "El campo {0} es necesario")]
    public float creditScore { get; set; }


    [Required(ErrorMessage = "El campo {0} es necesario")]
    public string citizen { get; set; } = null!;



    [Required(ErrorMessage = "El campo {0} es necesario")]
    public float income { get; set; }




}
