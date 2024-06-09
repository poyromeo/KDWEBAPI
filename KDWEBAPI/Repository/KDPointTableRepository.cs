using KDWEBAPI.DBHUBContext;
using KDWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KDWEBAPI.Repository
{
    public class KDPointTableRepository<KDPointTable> : IBaseRepository<KDPointTable> where KDPointTable : class
    {
        private readonly HBContext _context;
        public KDPointTableRepository(HBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KDPointTable>> ListAsync() => await _context.Set<KDPointTable>().ToListAsync();

        public async Task<KDPointTable> GetByIdAsync(int id) => await _context.Set<KDPointTable>().FindAsync(id);

        public async Task<KDPointTable> InsertAsync(KDPointTable entity)
        {
            await _context.Set<KDPointTable>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<KDPointTable> UpdateAsync(KDPointTable entity)
        {
            _context.Set<KDPointTable>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<KDPointTable> DeleteAsync(KDPointTable entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
