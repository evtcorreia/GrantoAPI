using System.ComponentModel.DataAnnotations;

namespace Granto.Models
{
    public class Oportunidade
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string cnpj { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public float valor { get; set; }
    }
}
