using Granto.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Granto.Data.Dtos.User
{
    public class UpdateUserDto
    {

        [Required]
        public string nome { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public Regioes regiao { get; set; }

        public DateTime dataUltimaOprtunidade { get; set; }
    }
}
