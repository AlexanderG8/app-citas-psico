using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models
{
    public class HISTORIAL_CITAS
    {
        [Key]
        public int ID_HISTORIAL_CITAS { get; set; }
        public int ID_CITAS { get; set; }
        public string? OBSERVACION { get; set; }
    }
}
