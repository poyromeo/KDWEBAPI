
using KDWEBAPI.DBHUBContext;
using KDWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KDWEBAPI.Repository
{
    public class KDCategoryRepository<KDCategory> : IBaseRepository<KDCategory> where KDCategory : class
    {
        private readonly HBContext _context;
        public KDCategoryRepository(HBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KDCategory>> ListAsync() => await _context.Set<KDCategory>().ToListAsync();

        public async Task<KDCategory> GetByIdAsync(int id) => await _context.Set<KDCategory>().FindAsync(id);

        public async Task<KDCategory> InsertAsync(KDCategory entity)
        {
            await _context.Set<KDCategory>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<KDCategory> UpdateAsync(KDCategory entity)
        {
            _context.Set<KDCategory>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<KDCategory> DeleteAsync(KDCategory entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
