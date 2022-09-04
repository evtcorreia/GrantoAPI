using System.ComponentModel.DataAnnotations;

namespace Granto.Data.Dtos.Oportunidades
{
    public class CreateOportunidadeDto
    {

       
        [Required]
        [RegularExpression("[0-9]{2}.?[0-9]{3}.?[0-9]{3}/?[0-9]{4}-?[0-9]{2}",
            ErrorMessage = "Informe um CNPJ válido...")]
        public string cnpj { get; set; }
        [Required (ErrorMessage = "O campo nome nao pode ser vazio")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O campo Valor nao pode ser vazio")]
        public float valor { get; set; }
        [Required(ErrorMessage = "O campo UserId nao recebeu valres")]
        public int UserId { get; set; }
    }
}
