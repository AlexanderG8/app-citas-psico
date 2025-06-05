using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models
{
    public class COLABORADOR
    {
        [Key]
        public int ID_COLABORADOR { get; set; }
        public string? NOMBRE_COMPLETO { get; set; }
        public string? TIPO_DOCUM { get; set; }
        public string? NUM_DOCUM { get; set; }
        public string? CORREO { get; set; }
        public string? TELEFONO { get; set; }
        public DateTime FECHA_NACIMIENTO { get; set; }
        public string? GENERO { get; set; }
        public bool ESTADO { get; set; }
    }
}
