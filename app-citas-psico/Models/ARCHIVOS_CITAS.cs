using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_citas_psico.Models
{
    public class ARCHIVOS_CITAS
    {
        [Key]
        public int ID_ARCHIVOS_CITAS { get; set; }
        public int ID_CITAS { get; set; }
        public string? NOMBRE_FILE { get; set; }
        public string? ARCHIVO { get; set; }
    }
}
