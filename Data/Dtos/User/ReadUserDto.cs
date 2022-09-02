using Granto.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Granto.Data.Dtos.User
{
    public class ReadUserDto
    {
        [Required]
        public string nome { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public Regioes regiao { get; set; }
    }
}
