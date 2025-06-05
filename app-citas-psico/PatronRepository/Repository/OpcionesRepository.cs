using app_citas_psico.Data;
using app_citas_psico.Models;
using app_citas_psico.Models.Procedures;
using app_citas_psico.PatronRepository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace app_citas_psico.PatronRepository.Repository
{
    public class OpcionesRepository : Repository<OPCIONES>, IOpcionesRepository
    {
        private readonly ApplicationDbContext _context;
        public OpcionesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(OPCIONES model)
        {
            var modelBD = _context.OPCIONES.FirstOrDefault(z => z.ID_OPCION == model.ID_OPCION);
            if (modelBD != null)
            {
                modelBD.OPCION = model.OPCION;
                _context.SaveChanges();
            }
        }

        public async Task<List<SP_LISTA_OPCIONES_USUARIO>> GetOpcionesUser(string dniUser)
        {
            var listOptions = await _context.SP_LISTA_OPCIONES_USUARIO.FromSqlRaw("SP_LISTA_OPCIONES_USUARIO @p0", dniUser).ToListAsync();
            return listOptions;
        }
    }
}
