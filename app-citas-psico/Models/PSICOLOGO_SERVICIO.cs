using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models
{
    public class PSICOLOGO_SERVICIO
    {
        [Key]
        public int ID_PSICOLOGO_SERVICIO { get; set; }
        public int ID_PSICOLOGO { get; set; }
        public int ID_SERVICIO { get; set; }
    }
}
