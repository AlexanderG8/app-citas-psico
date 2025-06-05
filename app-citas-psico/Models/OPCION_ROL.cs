using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models
{
    public class OPCION_ROL
    {
        [Key]
        public int ID_OPCION_ROL { get; set; }
        public int ID_OPCION { get; set; }
        public int ID_ROL { get; set; }
    }
}
