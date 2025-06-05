using System.ComponentModel.DataAnnotations;

namespace app_citas_psico.Models.Procedures
{
    public class SP_LISTA_OPCIONES_USUARIO
    {
        [Key]
        public int ID_OPCION { get; set; }
        public string? OPCION { get; set; }
        public string? CONTROLLER { get; set; }
        public string? ACCION { get; set; }
    }
}
