using KDWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KDWEBAPI.DBHUBContext
{
    public class HBContext : DbContext
    {
        public HBContext(DbContextOptions<HBContext> options) : base(options)
        {

        }
        public DbSet<KDProduct> KDProduct { get; set; }

        public DbSet<KDCategory> KDCategory { get; set; }

        public DbSet<KDSwiper> KDSwiper { get; set; }

        public DbSet<KDPointTable> KDPointTable { get; set; }
    }
}
