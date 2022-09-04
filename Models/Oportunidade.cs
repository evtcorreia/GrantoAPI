using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Granto.Models;

namespace Granto.Models
{
    public class Oportunidade
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [RegularExpression("[0-9]{2}-?[0-9]{3}-?[0-9]{3}/?[0-9]{4}-?[0-9]{2}",
            ErrorMessage = "Informe um CNPJ válido...")]
        public string cnpj { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public float valor { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        public int UserId { get; set; }
        
    }
}
