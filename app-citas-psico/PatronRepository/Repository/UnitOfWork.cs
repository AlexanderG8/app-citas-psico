using app_citas_psico.Data;
using app_citas_psico.PatronRepository.IRepository;

namespace app_citas_psico.PatronRepository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IOpcionesRepository Opciones { get; private set; }
        public IRolRepository Rol { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Opciones = new OpcionesRepository(_context);
            Rol = new RolRepository(_context);
        }

        /*
         * Dispose() se utiliza para liberar de manera explícita recursos no administrados, como archivos, 
         * conexiones a bases de datos, o manejadores de red, que no son gestionados automáticamente por el 
         * recolector de basura. Implementar y llamar a Dispose() garantiza que estos recursos se liberen de 
         * inmediato, evitando fugas de memoria y mejorando el rendimiento de la aplicación.
         */
        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
