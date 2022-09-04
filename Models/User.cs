using Granto.Models.Enums;
using System.ComponentModel.DataAnnotations;
using Granto.Models;
using System.Text.Json.Serialization;

namespace Granto.Models
{

    
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public Regioes regiao { get; set; }
        public DateTime dataUltimaOprtunidade { get; set; }
        [JsonIgnore]
        public virtual List<Oportunidade> Oportunidades { get; set; }


    }
}
