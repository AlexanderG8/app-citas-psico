using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models
{
    public class USUARIO_ROL
    {
        [Key]
        public int ID_USUARIO_ROL { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_ROL { get; set; }
    }
}
