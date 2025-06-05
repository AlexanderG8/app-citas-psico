using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models
{
    public class HORARIOS
    {
        [Key]
        public int ID_HORARIO { get; set; }
        public string? HORARIO { get; set; }
        public string? COD_HORARIO { get; set; }
        public TimeSpan HORA_INICIO { get; set; }
        public TimeSpan HORA_FIN { get; set; }
        public bool ESTADO { get; set; }
    }
}
