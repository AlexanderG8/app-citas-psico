using app_citas_psico.Models;

namespace app_citas_psico.PatronRepository.IRepository
{
    public interface IRolRepository : IRepository<ROL>
    {
        void Update(ROL model);
    }
}
