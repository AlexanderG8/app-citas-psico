using app_citas_psico.Data;
using app_citas_psico.PatronRepository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace app_citas_psico.PatronRepository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public async Task Save(T entidad)
        {
            await dbSet.AddAsync(entidad);
        }

        public async Task<T> GetID(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                //Filtrará la lista en base a lo indicado en la variable filtro
                query = query.Where(filtro);
            }
            if (incluirPropiedades != null)
            {
                /*
                 * Lo que hago al filtro incluirPropiedades es separar una cadena de caracteres
                 * por comas, remover los espacios vacios y almacenarlas una por una en una array. 
                 */
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }
            if (orderBy != null)
            {
                //Ordenara mi lista
                query = orderBy(query);
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetFirst(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                //Filtrará la lista en base a lo indicado en la variable filtro
                query = query.Where(filtro);
            }
            if (incluirPropiedades != null)
            {
                /*
                 * Lo que hago al filtro incluirPropiedades es separar una cadena de caracteres
                 * por comas, remover los espacios vacios y almacenarlas una por una en una array. 
                 */
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();
        }


        public void Remove(T entidad)
        {
            dbSet.Remove(entidad);
        }

        public void RemoveRange(IEnumerable<T> entidad)
        {
            dbSet.RemoveRange(entidad);
        }
    }
}
