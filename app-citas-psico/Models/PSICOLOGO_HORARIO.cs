using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models
{
    public class PSICOLOGO_HORARIO
    {
        [Key]
        public int ID_PSICOLOGO_HORARIO { get; set; }
        public int ID_PSICOLOGO { get; set; }
        public int ID_HORARIO { get; set; }
    }
}
