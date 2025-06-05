using System.Linq.Expressions;

namespace app_citas_psico.PatronRepository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetID(int id);

        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string incluirPropiedades = null,
            bool isTraking = true
            );
        Task<T> GetFirst(
            Expression<Func<T, bool>> filtro = null,
            string incluirPropiedades = null,
            bool isTraking = true
            );

        Task Save(T entidad);

        void Remove(T entidad);

        void RemoveRange(IEnumerable<T> entidad);
    }
}
