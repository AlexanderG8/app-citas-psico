using app_citas_psico.Data;
using app_citas_psico.Models;
using app_citas_psico.PatronRepository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace app_citas_psico.PatronRepository.Repository
{
    public class RolRepository : Repository<ROL>, IRolRepository
    {
        private readonly ApplicationDbContext _context;
        public RolRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(ROL model)
        {
            var modelBD = _context.ROL.FirstOrDefault(z => z.ID_ROL == model.ID_ROL);
            if (modelBD != null)
            {
                modelBD.NOMBRE_ROL = model.NOMBRE_ROL;
                _context.SaveChanges();
            }
        }
    }
}
