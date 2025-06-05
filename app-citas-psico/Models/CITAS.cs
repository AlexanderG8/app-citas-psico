using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models
{
    public class CITAS
    {
        [Key]
        public int ID_CITAS { get; set; }
        public int ID_CLIENTE { get; set; }
        public int ID_SERVICIO { get; set; }
        public int ID_PSICOLOGO { get; set; }
        public int ID_COLABORADOR { get; set; }
        public DateTime FECHA_CITA { get; set; }
        public TimeSpan HORA_INICIO { get; set; }
        public TimeSpan HORA_FIN { get; set; }
        public string? OBSERVACION { get; set; }
        public string? ESTADO { get; set; } // PROGRAMADA - CANCELADA - COMPLETADA
    }
}
