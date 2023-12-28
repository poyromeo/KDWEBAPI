using KDWEBAPI.DBHUBContext;
using KDWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KDWEBAPI.Repository
{
    public class KDProductRepository<KDProduct> : IBaseRepository<KDProduct> where KDProduct : class
    {
        private readonly HBContext _context;
        public KDProductRepository(HBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KDProduct>> ListAsync() => await _context.Set<KDProduct>().ToListAsync();

        public async Task<KDProduct> GetByIdAsync(int id) => await _context.Set<KDProduct>().FindAsync(id);

        public async Task<KDProduct> InsertAsync(KDProduct entity)
        {
            await _context.Set<KDProduct>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<KDProduct> UpdateAsync(KDProduct entity)
        {
            _context.Set<KDProduct>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<KDProduct> DeleteAsync(KDProduct entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
