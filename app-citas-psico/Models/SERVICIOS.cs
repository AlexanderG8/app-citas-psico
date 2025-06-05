using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models
{
    public class SERVICIOS
    {
        [Key]
        public int ID_SERVICIO { get; set; }
        public string? SERVICIO { get; set; }
        public decimal PRECIO { get; set; }
        public bool ESTADO { get; set; }
    }
}
