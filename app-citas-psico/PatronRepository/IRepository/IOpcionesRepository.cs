using app_citas_psico.Models;
using app_citas_psico.Models.Procedures;

namespace app_citas_psico.PatronRepository.IRepository
{
    public interface IOpcionesRepository : IRepository<OPCIONES>
    {
        void Update(OPCIONES model);
        Task<List<SP_LISTA_OPCIONES_USUARIO>> GetOpcionesUser(string dniUser);
    }
}
