using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models
{
    public class USUARIO
    {
        [Key]
        public int ID_USUARIO { get; set; }
        public string? DNI { get; set; }
        public string? CONTRASEÑA { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public bool ESTADO { get; set; }
    }
}
