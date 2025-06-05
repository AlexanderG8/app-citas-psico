using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models
{
    public class ROL
    {
        [Key]
        public int ID_ROL { get; set; }
        public string? NOMBRE_ROL { get; set; }
    }
}
