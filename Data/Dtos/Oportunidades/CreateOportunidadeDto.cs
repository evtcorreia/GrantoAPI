using System.ComponentModel.DataAnnotations;

namespace Granto.Data.Dtos.Oportunidades
{
    public class CreateOportunidadeDto
    {

       
        [Required]
        [RegularExpression("[0-9]{2}-?[0-9]{3}-?[0-9]{3}/?[0-9]{4}-?[0-9]{2}",
            ErrorMessage = "Informe um email válido...")]
        public string cnpj { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public float valor { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
