using KDWEBAPI.DBHUBContext;
using KDWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KDWEBAPI.Repository
{
    public class KDSwiperRepository<KDSwiper> : IBaseRepository<KDSwiper> where KDSwiper : class
    {
        private readonly HBContext _context;
        public KDSwiperRepository(HBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KDSwiper>> ListAsync() => await _context.Set<KDSwiper>().ToListAsync();

        public async Task<KDSwiper> GetByIdAsync(int id) => await _context.Set<KDSwiper>().FindAsync(id);

        public async Task<KDSwiper> InsertAsync(KDSwiper entity)
        {
            await _context.Set<KDSwiper>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<KDSwiper> UpdateAsync(KDSwiper entity)
        {
            _context.Set<KDSwiper>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<KDSwiper> DeleteAsync(KDSwiper entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
